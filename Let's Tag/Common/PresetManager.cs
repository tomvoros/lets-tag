using System;
using System.IO;
using System.Reflection;

namespace LetsTag.Common
{
    public class PresetManager
    {
        static readonly string APPLICATION_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static readonly string PRESETS_PATH = APPLICATION_PATH + @"\Presets";

        public static Stream OpenPresetFile(string path, FileMode mode, FileAccess access)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            try
            {
                Directory.SetCurrentDirectory(PRESETS_PATH);
                return File.Open(path, mode, access);
            }
            catch (Exception ex)
            {
                throw new LetsTagException("Could not access presets directory", ex);
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }

        public static bool PresetFileExists(string path)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            try
            {
                Directory.SetCurrentDirectory(PRESETS_PATH);
                return File.Exists(path);
            }
            catch (Exception ex)
            {
                throw new LetsTagException("Could not access presets directory", ex);
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }

        public static void DeletePresetFile(string path)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            try
            {
                Directory.SetCurrentDirectory(PRESETS_PATH);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw new LetsTagException("Could not access presets directory", ex);
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }

        public static string[] GetPresetFiles()
        {
            string[] presetFiles = Directory.GetFiles(PRESETS_PATH, "*.xml", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < presetFiles.Length; i++)
                presetFiles[i] = Path.GetFileName(presetFiles[i]);
            return presetFiles;
        }
    }
}
