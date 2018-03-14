namespace Gallery
{
    static class SizeCalculating
    {
        static public string Calculate(double size)
        {
            string output = $"{size} Bytes";
            if (size >= 1000)
                output = $"{(size /= 1000).ToString("0.##")} KB";
            if (size >= 1000)
                output = $"{(size /= 1000).ToString("0.##")} MB";
            if (size >= 1000)
                output = $"{(size /= 1000).ToString("0.##")} GB";
            return output;
        }
    }
}
