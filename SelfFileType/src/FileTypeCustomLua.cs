using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;
using SelfFileType.src.types;
using static System.Windows.Forms.AxHost;

namespace SelfFileType.src
{
    public class FileTypeCustomLua
    {

        /*
        public static void NeoLua()
        {
            using (var lua = new Neo.IronLua.Lua())
            {
                dynamic env = lua.CreateEnvironment(); // Create a environment
                env.dochunk("a = 'Hallo World!';", "test.lua"); // Create a variable in Lua
                Console.WriteLine(env.a); // Access a variable in C#
                env.dochunk("function add(b) return b + 3; end;", "test.lua"); // Create a function in Lua
                Console.WriteLine("Add(3) = {0}", env.add(3)); // Call the function in C#

                env.dochunk("function Urls() return {'docker.com'}; end", "test.lua"); // Create a variable in Lua
                var urls = ResultStringArray(env.Urls());
                foreach (var item in urls)
                {
                    Console.WriteLine(item);
                }
            }
        }
        */

        public static List<FileTypeBaseSite> ReadAllLua()
        {
            var fts = new List<FileTypeBaseSite>();

            var luaFolder = Config.Instance.GetCustomFolder();
            var files = from file in Directory.EnumerateFiles(luaFolder, "*.lua", SearchOption.AllDirectories)
                        select File.ReadAllText(file);

            foreach (var f in files)
            {
                if (!string.IsNullOrWhiteSpace(f))
                {
                    fts.Add(BuildForLuaString(f));
                }
            }

            return fts;
        }


        public static FileTypeCustom BuildForLuaString(string luaStr)
        {
            //return BuildForLuaString_NeoLua(luaStr);
            return BuildForLuaString_NLua(luaStr);
        }

        public static FileTypeCustom BuildForLuaString_NeoLua(string luaStr)
        {
            var ftc = new FileTypeCustom();
            /*
            using (var lua = new Neo.IronLua.Lua())
            {

                dynamic env = lua.CreateEnvironment(); // Create a environment
                env.dochunk(luaStr, "test.lua"); // Create a variable in Lua

                ftc.CustomDescription = env.Description();
                ftc.CustomExtensionName = env.ExtensionName();
                ftc.CustomIcon = env.Icon();
                ftc.CustomUrls = ResultStringArray(env.Urls());
                if (env.FileName != null)
                {
                    ftc.CustomFileName = (url) =>
                    {
                        return env.FileName(url);
                    };
                }
            }
            */
            return ftc;
        }

        public static FileTypeCustom BuildForLuaString_NLua(string luaStr)
        {
            var ftc = new FileTypeCustom();
            var lua = new Lua();
            lua.State.Encoding = Encoding.UTF8;
            lua.DoString(luaStr);

            //var lua = new Lua();

            var rDescription = lua.GetFunction("Description").Call();
            var rExtensionName = lua.GetFunction("ExtensionName").Call();
            var rIcon = lua.GetFunction("Icon").Call();
            var rCustomUrls = lua.GetFunction("Urls").Call();

            // LuaFunction.Call will also return a array of objects, since a Lua function
            // can return multiple values
            ftc.CustomDescription = (string)rDescription.First();
            ftc.CustomExtensionName = (string)rExtensionName.First();
            ftc.CustomIcon = (string)rIcon.First();
            ftc.CustomUrls = ResultStringArray((LuaTable)rCustomUrls.First());

            if (lua.GetFunction("FileName") != null)
            {
                ftc.CustomFileName = (url) =>
                {
                    var rs = lua.GetFunction("FileName").Call(url);
                    var filename = rs.First().ToString();
                    lua.Close();
                    return filename;
                };
            }
            //lua.Close();
            return ftc;
        }




        public static List<String> ResultStringArray(dynamic table)
        {
            List<String> strs = new List<string>();
            foreach (KeyValuePair<object, object> item in table[0])
            {
                //Console.WriteLine(item.Value);
                if (item.Value is string)
                {
                    strs.Add((string)item.Value);
                }
            }
            return strs;
        }

        public static List<String> ResultStringArray(LuaTable table)
        {
            List<String> strs = new List<string>();
            foreach (KeyValuePair<object, object> item in table)
            {
                //Console.WriteLine(item.Value);
                if (item.Value is string)
                {
                    strs.Add((string)item.Value);
                }
            }
            return strs;
        }


        public static dynamic BuildLuaEnv(string luaStr)
        {
            //var lua = new Neo.IronLua.Lua();
            //dynamic env = lua.CreateEnvironment(); // Create a environment
            //env.dochunk(luaStr, "test.lua"); // Create a variable in Lua
            //return env;
            return null;
        }

        public static bool TestLua(string luaStr)
        {
            //using (var lua = new Neo.IronLua.Lua())
            //{
            //    dynamic env = lua.CreateEnvironment(); // Create a environment
            //    env.dochunk(luaStr, "test.lua"); // Create a variable in Lua
            //    return env.Icon != null;
            //}
            return false;
        }
    }
}
