import tcod
import tcod.event
from ArrayOfBytes import ArrayOfBytes
from tkinter import Tk


MAX_BYTE_WIDTH = 8
MAX_BYTE_COLUMN = MAX_BYTE_WIDTH * 3
MAX_BYTE_HEIGHT = None
SCREEN_WIDTH = 40
SCREEN_HEIGHT = 46
FONT = "dejavu16x16_gs_tc.png"
TK = Tk()


def readFromFile():
    fp = open("item_aob.txt")
    lines = fp.readlines()
    fp.close()
    return lines


# DisplayByteWindow(root_console, AoB.bytes[status["userY"] * MAX_BYTE_WIDTH + status["userX"]])
def DisplayByteWindow(console, byteObj):
    cursorY = 2
    cursorX = MAX_BYTE_COLUMN+1
    console.print(cursorX, cursorY, F"OFFSET: {byteObj.offset:#06X}")
    cursorY += 1
    console.print(cursorX, cursorY, F"UNIQ/SUM: {byteObj.count()}/{byteObj.total()}")
    cursorY += 2
    for byteTxt, byteCounter in byteObj.bytes.items():
        console.print(cursorX, cursorY, F"{byteTxt}:", fg=tcod.lighter_pink)
        cursorY += 1
        console.print(cursorX+1, cursorY, F"CNT: {byteCounter.count}", fg=tcod.dark_pink)
        cursorY += 1
        cursorX += 2
        for typeStr, typeCount in byteCounter.type.items():
            console.print(cursorX, cursorY, F"{typeStr}={typeCount}", fg=tcod.lighter_green)
            cursorY += 1
        cursorX -= 2
        cursorY += 2
    pass


def main():
    global MAX_BYTE_HEIGHT
    lines = readFromFile()
    AoB = ArrayOfBytes(lines.pop(), lines)
    MAX_BYTE_HEIGHT = int(AoB.length() / MAX_BYTE_WIDTH) - 1
    tcod.console_set_custom_font(
        FONT, tcod.FONT_LAYOUT_TCOD | tcod.FONT_TYPE_GREYSCALE
    )

    status = {"userX": 0, "userY": 0}

    with tcod.console_init_root(SCREEN_WIDTH, SCREEN_HEIGHT,
                                renderer=tcod.RENDERER_SDL2,
                                order="F", vsync=True) as root_console:
        while True:
            root_console.clear()
            AoB.display(root_console, 1, 1, status)
            DisplayByteWindow(root_console, AoB.bytes[status["userY"] * MAX_BYTE_WIDTH + status["userX"]])
            tcod.console_flush()
            for event in tcod.event.wait():
                if event.type == "QUIT":
                    raise SystemExit()
                if event.type == "KEYDOWN":
                    if event.sym == tcod.event.K_ESCAPE:
                        raise SystemExit("USER-INITIATED TERMINATION")
                    elif event.sym == tcod.event.K_LEFT and status["userX"] >= 0:
                        if status["userX"] == 0 and status["userY"] > 0:
                            status["userX"] = MAX_BYTE_WIDTH-1
                            status["userY"] -= 1
                        elif status["userX"] > 0:
                            status["userX"] -= 1
                    elif event.sym == tcod.event.K_RIGHT and status["userX"] <= (MAX_BYTE_WIDTH-1):
                        if status["userX"] == (MAX_BYTE_WIDTH-1) and status["userY"] < MAX_BYTE_HEIGHT:
                            status["userX"] = 0
                            status["userY"] += 1
                        elif status["userX"] < (MAX_BYTE_WIDTH - 1):
                            status["userX"] += 1
                    elif event.sym == tcod.event.K_UP and status["userY"] > 0:
                        status["userY"] -= 1
                    elif event.sym == tcod.event.K_DOWN and status["userY"] < MAX_BYTE_HEIGHT:
                        status["userY"] += 1
                    elif event.sym == tcod.event.K_TAB:
                        offset = status["userY"] * MAX_BYTE_WIDTH + status["userX"]
                        reverse = bool(event.mod & tcod.event.KMOD_SHIFT)
                        nextOffset = AoB.findNext(offset+1, reverse)
                        if nextOffset is not None:
                            status["userY"] = int(nextOffset / MAX_BYTE_WIDTH)
                            status["userX"] = nextOffset % MAX_BYTE_WIDTH
                    elif event.sym == tcod.event.K_INSERT:
                        if bool(event.mod & tcod.event.KMOD_SHIFT):
                            i = TK.clipboard_get()
                            TK.clipboard_clear()
                            print(i)
                        else:
                            TK.clipboard_append(AoB.generateTemplate())


if __name__ == "__main__":
    main()
