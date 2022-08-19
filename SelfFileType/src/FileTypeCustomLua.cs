using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo.IronLua;
using SelfFileType.src.types;

namespace SelfFileType.src
{
    public class FileTypeCustomLua
    {

        public static void Lua()
        {
            using (Lua lua = new Lua())
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

        public static List<FileTypeBaseSite> ReadAllLua()
        {
            var fts = new List<FileTypeBaseSite>();

            var appFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            var luaFolder = "custom";
            string docPath = Path.Combine(appFolder, luaFolder);
            var files = from file in Directory.EnumerateFiles(docPath, "*.lua", SearchOption.AllDirectories)
                        select File.ReadAllText(file);

            using (Lua lua = new Lua())
            {
                foreach (var f in files)
                {
                    if (!string.IsNullOrWhiteSpace(f))
                    {
                        fts.Add(BuildForLuaString(f));
                    }
                }
            }

            return fts;
        }

        public static FileTypeCustom BuildForLuaString(string luaStr)
        {
            using (Lua lua = new Lua())
            {
                return BuildForLuaString(lua, luaStr);
            }
        }
        public static FileTypeCustom BuildForLuaString(Lua lua, string luaStr)
        {
            var ftc = new FileTypeCustom();

            dynamic env = lua.CreateEnvironment(); // Create a environment
            env.dochunk(luaStr, "test.lua"); // Create a variable in Lua

            ftc.CustomDescription = env.Description();
            ftc.CustomExtensionName = env.ExtensionName();
            ftc.CustomIcon = env.Icon();
            ftc.CustomUrls = ResultStringArray(env.Urls());

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

    }
}
