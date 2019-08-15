import tcod

MAX_BYTE_WIDTH = 8


class Counter(dict):
    def __missing__(self, key):
        return 0


class ArrayOfBytes:
    def __init__(self, instr, *lines):
        bytes_raw = instr.split()
        self.type = bytes_raw.pop(0)
        self.bytes = []
        self.totalCompares = 1
        for i in range(len(bytes_raw)):
            self.bytes.append(ByteInSequence(i, bytes_raw[i], self.type))

        if len(lines) == 0:
            return

        for line in lines[0]:
            self.checkNewArray(ArrayOfBytes(line))

    def length(self):
        return len(self.bytes)

    def checkNewArray(self, aobCheck):
        if self.length() != aobCheck.length():
            raise ValueError("AoB sequences must be same length.")
        self.totalCompares += 1
        for b1, b2 in zip(self.bytes, aobCheck.bytes):
            b1.addByte(b2)

    def generateTemplate(self):
        templateString = ""
        for byte in self.bytes:
            if byte.count() == 1:
                templateString += F"{list(byte.bytes.keys())[0]} "
            else:
                templateString += "?? "
        templateString = templateString.rstrip()
        return templateString

    def display(self, con, x, y, status):
        newLine = 8
        cursorX = x
        userOffset = status["userY"] * MAX_BYTE_WIDTH + status["userX"]
        for byteobj in self.bytes:
            count = byteobj.count()
            bg = tcod.black
            if byteobj.offset == userOffset:
                bg = tcod.yellow
                fg = tcod.dark_grey
            elif count == 1:
                fg = tcod.dark_grey
            elif count <= self.totalCompares // 4:
                fg = tcod.green
            elif count <= self.totalCompares // 2:
                fg = tcod.yellow
            elif count <= (3 * self.totalCompares) // 4:
                fg = tcod.red
            else:
                fg = tcod.grey
                bg = tcod.dark_red
            con.print(cursorX, y, byteobj.toString(), fg, bg)
            cursorX += 3

            newLine -= 1
            if newLine == 0:
                y += 1
                cursorX = x
                newLine = 8

    def findNext(self, start, reverse=False):
        if reverse is False:
            for b in self.bytes[start:]:
                if b.count() > 1:
                    return b.offset
            for b in self.bytes[:start]:
                if b.count() > 1:
                    return b.offset
        else:
            firstHalfBytes = self.bytes[:start-1]
            firstHalfBytes.reverse()
            for b in firstHalfBytes:
                if b.count() > 1:
                    return b.offset
            secondHalfBytes = self.bytes[start:]
            secondHalfBytes.reverse()
            for b in secondHalfBytes:
                if b.count() > 1:
                    return b.offset
            # for b in self.bytes[start:].reverse():
            #     if b.count() > 1:
            #         return b.offset
            # for b in self.bytes[:start].reverse():
            #     if b.count() > 1:
            #         return b.offset
        return None

    def byteAt(self, param):
        pass


class ByteInSequence:
    def __init__(self, offset, byte, itemType):
        self.offset = offset
        self.bytes = Counter()
        self.bytes[byte] = ByteCounter()
        self.bytes[byte].count += 1
        self.bytes[byte].type[itemType] += 1
        self.type = itemType

    def toString(self):
        if self.count() == 1:
            return list(self.bytes.keys())[0]
        else:
            return "??"

    def count(self):
        return len(self.bytes)

    def total(self):
        cnt = 0
        for bc in self.bytes.values():
            cnt += bc.count
        return cnt

    def addByte(self, checkBIS):
        if self.offset != checkBIS.offset:
            raise ValueError(F"self.offset({self.offset}) != checkBIS.offset({checkBIS.offset})")
        for checkByte in checkBIS.bytes.keys():
            if checkByte in self.bytes:
                self.bytes[checkByte].count += 1
                self.bytes[checkByte].type[checkBIS.type] += 1
            else:
                self.bytes[checkByte] = ByteCounter()
                self.bytes[checkByte].count += 1
                self.bytes[checkByte].type[checkBIS.type] += 1


class ByteCounter:
    def __init__(self):
        self.count = 0
        self.type = Counter()
