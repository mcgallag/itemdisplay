using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace IsaacMonitor
{
    [DataContract]
    internal class GameInfo
    {
        [DataMember]
        internal int Rocks;
        [DataMember]
        internal int TintedRocks;
        [DataMember]
        internal int Poops;
        [DataMember]
        internal int ShopKeeps;
        [DataMember]
        internal int DevilDeals;
        [DataMember]
        internal int Donations;

        public static GameInfo ZERO = new GameInfo();

        public static bool operator ==(GameInfo v1, GameInfo v2)
        {
            if ((v1.Rocks == v2.Rocks) && (v1.TintedRocks == v2.TintedRocks) &&
                (v1.Poops == v2.Poops) && (v1.ShopKeeps == v2.ShopKeeps) &&
                (v1.DevilDeals == v2.DevilDeals) && (v1.Donations == v2.Donations))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(GameInfo v1, GameInfo v2)
        {
            return !(v1 == v2);
        }

        internal string Json()
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(GameInfo));
            ser.WriteObject(stream, this);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }

    class IsaacMemoryReader
    {
        const string PROC_NAME = "isaac-ng";
        const string AOB_SCAN_QUERY = "00 ?? ?? ?? 00 ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 0B 00 00 ?? ?? 00 ?? ?? ?? ?? 00 00 00 04";
        const string TEMPLATE = "0x{0:X}";
        //const string OUTFILE = "isaac.json";
        const string OUTFILE = "H:/dev/cs/IsaacMonitor/web/isaac.json";

        private long baseAddress;
        private const long rocksOffset = 0x200;
        private const long tintedRocksOffset = 0x204;
        private const long poopsOffset = 0x20C;

        internal void WriteToFile()
        {
            //throw new NotImplementedException();
            File.WriteAllText(OUTFILE, Game.Json());
        }

        private const long shopkeepsOffset = 0x228;
        private const long devilsOffset = 0x238;
        private const long donationOffset = 0x248;

        private GameInfo Game;
        public GameInfo GetGame()
        {
            GameUpdated = false;
            return Game;
        }

        public bool GameUpdated { get; private set; }

        private Mem MemoryReader;
        public bool Attached { get; private set; }

        public bool HaveBaseAddress
        {
            get
            {
                return baseAddress != 0;
            }
        }

        public void Update()
        {
            if (Attached && HaveBaseAddress)
            {
                GameInfo ngi = ReadFromMemory();
                if (ngi != Game)
                {
                    Game = ngi;
                    GameUpdated = true;
                }
                if (ngi == GameInfo.ZERO)
                {
                    if (MemoryReader.getProcIDFromName(PROC_NAME) == 0)
                    {
                        Attached = false;
                        baseAddress = 0;
                        return;
                    }
                }
            }
        }

        private GameInfo ReadFromMemory()
        {
            GameInfo ngi = new GameInfo();
            ngi.Rocks = MemoryReader.readInt(GetAddr(rocksOffset));
            ngi.TintedRocks = MemoryReader.readInt(GetAddr(tintedRocksOffset));
            ngi.Poops = MemoryReader.readInt(GetAddr(poopsOffset));
            ngi.ShopKeeps = MemoryReader.readInt(GetAddr(shopkeepsOffset));
            ngi.DevilDeals = MemoryReader.readInt(GetAddr(devilsOffset));
            ngi.Donations = MemoryReader.readInt(GetAddr(donationOffset));
            return ngi;
        }

        private string GetAddr(long offset)
        {
            return string.Format(TEMPLATE, baseAddress + offset);
        }

        public IsaacMemoryReader()
        {
            MemoryReader = new Mem();
            Attached = false;
            Game = new GameInfo();
        }


        internal bool Attach()
        {
            if (!Attached)
            {
                int pid = MemoryReader.getProcIDFromName(PROC_NAME);
                if (pid != 0)
                {
                    Attached = MemoryReader.OpenProcess(pid);
                    GameUpdated = Attached;
                }
            }

            return Attached;
        }

        internal void Detach()
        {
            if (Attached)
            {
                MemoryReader.closeProcess();
                Attached = false;
            }
        }

        internal async Task AoBScanAsync()
        {
            IEnumerable<long> vs = await MemoryReader.AoBScan(AOB_SCAN_QUERY, writable: true);
            baseAddress = vs.Single();
        }
    }
}
