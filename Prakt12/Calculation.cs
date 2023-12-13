namespace Prakt12
{
    class Calculation
    {
        /// <summary>
        /// Расчитывает объем и площадь поверхности куба
        /// </summary>
        /// <param name="side">Длина ребра куба</param>
        /// <param name="volume">Объем куба</param>
        /// <param name="area">Площадь поверхности куба</param>
        public static void CubeVolumeAndArea(long side, out long volume, out long area)
        {
            volume = side * side * side;
            area = 6 * side * side;
        }

        /// <summary>
        /// Расчитывает количество полных тонн и килограмм
        /// </summary>
        /// <param name="mass">Масса в килограммах</param>
        /// <param name="tons">Количество полных тонн</param>
        /// <param name="remainingKilograms">Количество оставшихся килограмм</param>
        public static void TonsAndKilograms(int mass, out int tons, out int remainingKilograms)
        {
            tons = mass / 1000;
            remainingKilograms = mass % 1000;
        }
    }
}
