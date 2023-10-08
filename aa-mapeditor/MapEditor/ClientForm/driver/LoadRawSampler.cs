/* sample code 2023/10/08 */
namespace ClientForm.driver
{
    internal class LoadRawSampler
    {
        private const string BG_CHIPIMAGE_GRAPHIC_FILE = "C:\\Users\\you nanase\\ローカルプロジェクト\\r2-refined\\r2-refined\\r2-refined\\assets\\2_BG\\demostage_BG.png";
        public List<Image> ImageList { get; } = new();

        private const string MAPFIELD_BINARY_FILE = "C:\\Users\\you nanase\\ローカルプロジェクト\\r2-refined\\r2-refined\\r2-refined\\assets\\1_Mapdata\\demostage_mapdata.bin";
        public byte[,] MapFields { get; } = new byte[15, 16];


        public LoadRawSampler() { }

        public void LoadImageList()
        {
            Image image = Image.FromFile(BG_CHIPIMAGE_GRAPHIC_FILE);
            if (image != null)
            {
                const int CHIPRAWSIZE = 16;
                const int CHIPLIST_TABLE_CELL_SIZE = 48!;
                for (int row = 0; row < 15; row++)
                {
                    for (int col = 0; col < 16; col++)
                    {
                        Rectangle box = new(0, 0, 32, 32);
                        Rectangle img_rect = new(col % 16 / 1 * CHIPRAWSIZE, row * CHIPRAWSIZE, CHIPRAWSIZE - 1, CHIPRAWSIZE - 1);
                        Bitmap bitmap = new(CHIPLIST_TABLE_CELL_SIZE, CHIPLIST_TABLE_CELL_SIZE);
                        Graphics graphics = Graphics.FromImage(bitmap);
                        graphics.DrawImage(image, box, img_rect, GraphicsUnit.Pixel);
                        ImageList.Add(bitmap);
                    }
                }
            }
        }

        public void LoadMapFields()
        {
            using var fs = File.OpenRead(MAPFIELD_BINARY_FILE);
            var binary = new BinaryReader(fs);
            long len = fs.Length;
            byte[] data = new byte[len];
            binary.Read(data, 0, (int)len);
            if (data.Length > 0)
            {
                for (int i = 0; i < MapFields.GetLength(0); i++)
                {
                    for (int j = 0; j < MapFields.GetLength(1); j++)
                    {
                        MapFields[i, j] = data[0x10 + (i * MapFields.GetLength(1)) + j];
                    }
                }
            }
        }
    }
}
