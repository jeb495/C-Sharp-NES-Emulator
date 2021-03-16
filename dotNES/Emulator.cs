using dotNES.Controllers;
using dotNES.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


//emulator settings are set here in the "Emulator Class"
namespace dotNES
{
    class Emulator
    {
        private static readonly Dictionary<int, KeyValuePair<Type, MapperDef>> Mappers = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                                                                          let def = (MapperDef)type.GetCustomAttributes(typeof(MapperDef), true).FirstOrDefault()
                                                                                          where def != null
                                                                                          select new { def, type }).ToDictionary(a => a.def.Id, a => new KeyValuePair<Type, MapperDef>(a.type, a.def));

        //seting definitions for the controller, CPU, PPU, among others
        public IController Controller;

        public readonly CPU CPU;

        public readonly PPU PPU;

        public readonly BaseMapper Mapper;

        public readonly Cartridge Cartridge;

        private readonly string _path;

        public Emulator(string path, IController controller)
        {
            _path = path;
            Cartridge = new Cartridge(path);
            if (!Mappers.ContainsKey(Cartridge.MapperNumber))
                throw new NotImplementedException($"unsupported mapper {Cartridge.MapperNumber}");
            Mapper = (BaseMapper)Activator.CreateInstance(Mappers[Cartridge.MapperNumber].Key, this);
            CPU = new CPU(this);
            PPU = new PPU(this);
            Controller = controller;

            Load();
        }

        //save option
        public void Save()
        {
            using (var fs = new FileStream(_path + ".sav", FileMode.Create, FileAccess.Write))
            {
                Mapper.Save(fs);
            }
        }
        //load option
        public void Load()
        {
            var sav = _path + ".sav";
            if (!File.Exists(sav)) return;

            using (var fs = new FileStream(sav, FileMode.Open, FileAccess.Read))
            {
                Mapper.Load(fs);
            }
        }
    }
}
