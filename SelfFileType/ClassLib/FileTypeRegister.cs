﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFileType.ClassLib
{

    /// <summary>  
    /// 注册自定义的文件类型。  
    /// </summary>  
    public class FileTypeRegister
    {
        /// <summary>  
        /// 使文件类型与对应的图标及应用程序关联起来
        /// </summary>          
        public static void RegisterFileType(FileTypeRegInfo regInfo)
        {
            if (FileTypeRegistered(regInfo.ExtendName))
            {
                UnregisterFileType(regInfo.ExtendName);
            }

            //HKEY_CLASSES_ROOT/.osf
            RegistryKey fileTypeKey = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
            string relationName = regInfo.ExtendName.Substring(1,
                                                               regInfo.ExtendName.Length - 1).ToUpper() + "_FileType";
            fileTypeKey.SetValue("", relationName);
            if (regInfo.ShellNew)
            {
                var shellNew = fileTypeKey.CreateSubKey("ShellNew");
                //shellNew.SetValue("NullFile", "");
                shellNew.SetValue("FileName", "Template" + regInfo.ExtendName);
                shellNew.SetValue("ItemName", @"@%SystemRoot%\system32\notepad.exe,-470");

                var cShellNew = @"C:\Windows\ShellNew\" + "Template" + regInfo.ExtendName;
                File.Delete(cShellNew);
                using (StreamWriter sw = File.CreateText(cShellNew))
                {
                    sw.Write(regInfo.ShellNewTemplate);
                }
            }
            fileTypeKey.Close();

            //HKEY_CLASSES_ROOT/OSF_FileType
            RegistryKey relationKey = Registry.ClassesRoot.CreateSubKey(relationName);
            relationKey.SetValue("", regInfo.Description);

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell/DefaultIcon
            RegistryKey iconKey = relationKey.CreateSubKey("DefaultIcon");
            iconKey.SetValue("", regInfo.IconPath);

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell
            RegistryKey shellKey = relationKey.CreateSubKey("Shell");

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell/Open
            RegistryKey openKey = shellKey.CreateSubKey("Open");

            //HKEY_CLASSES_ROOT/OSF_FileType/Shell/Open/Command
            RegistryKey commandKey = openKey.CreateSubKey("Command");
            commandKey.SetValue("", regInfo.ExePath + " \"%1\""); // " %1"表示将被双击的文件的路径传给目标应用程序
            relationKey.Close();
        }


        public static void UnregisterFileType(string extendName)
        {
            //HKEY_CLASSES_ROOT/.osf
            //RegistryKey fileTypeKey = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
            //Registry.ClassesRoot.DeleteSubKey(extendName, false);
            Registry.ClassesRoot.DeleteSubKeyTree(extendName, false);

            string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";


            //HKEY_CLASSES_ROOT/OSF_FileType
            //RegistryKey relationKey = Registry.ClassesRoot.CreateSubKey(relationName);
            Registry.ClassesRoot.DeleteSubKeyTree(relationName, false);

        }

        /// <summary>  
        /// 更新指定文件类型关联信息  
        /// </summary>      
        public static bool UpdateFileTypeRegInfo(FileTypeRegInfo regInfo)
        {
            if (!FileTypeRegistered(regInfo.ExtendName))
            {
                return false;
            }

            string extendName = regInfo.ExtendName;
            string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
            RegistryKey relationKey = Registry.ClassesRoot.OpenSubKey(relationName, true);
            relationKey.SetValue("", regInfo.Description);
            RegistryKey iconKey = relationKey.OpenSubKey("DefaultIcon", true);
            iconKey.SetValue("", regInfo.IconPath);
            RegistryKey shellKey = relationKey.OpenSubKey("Shell");
            RegistryKey openKey = shellKey.OpenSubKey("Open");
            RegistryKey commandKey = openKey.OpenSubKey("Command", true);
            commandKey.SetValue("", regInfo.ExePath + " %1");
            relationKey.Close();
            return true;
        }

        /// <summary>  
        /// 获取指定文件类型关联信息  
        /// </summary>          
        public static FileTypeRegInfo GetFileTypeRegInfo(string extendName)
        {
            if (!FileTypeRegistered(extendName))
            {
                return null;
            }
            FileTypeRegInfo regInfo = new FileTypeRegInfo(extendName);

            string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
            RegistryKey relationKey = Registry.ClassesRoot.OpenSubKey(relationName);
            regInfo.Description = relationKey.GetValue("").ToString();
            RegistryKey iconKey = relationKey.OpenSubKey("DefaultIcon");
            regInfo.IconPath = iconKey.GetValue("").ToString();
            RegistryKey shellKey = relationKey.OpenSubKey("Shell");
            RegistryKey openKey = shellKey.OpenSubKey("Open");
            RegistryKey commandKey = openKey.OpenSubKey("Command");
            string temp = commandKey.GetValue("").ToString();
            regInfo.ExePath = temp.Substring(0, temp.Length - 3);
            return regInfo;
        }

        /// <summary>  
        /// 指定文件类型是否已经注册  
        /// </summary>          
        public static bool FileTypeRegistered(string extendName)
        {
            RegistryKey softwareKey = Registry.ClassesRoot.OpenSubKey(extendName);
            if (softwareKey != null)
            {
                return true;
            }
            return false;
        }
    }


}
