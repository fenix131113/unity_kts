namespace StaticKT
{
    public static class Calculator
    {
        private static ConstDataSO _gravityConstData;
        private static ConstDataSO _gravitationalAttractionConstData;

        public static void SetData(ConstDataSO gravityConstData, ConstDataSO universalGravityConst)
        {
            _gravityConstData = gravityConstData;
            _gravitationalAttractionConstData = universalGravityConst;
        }
        
        // H=gt^2/2
        public static double CalculateFallHeight(double t)
        {
            return _gravityConstData.ConstValue * (t * t) / 2;
        }
        
        // h=v0t - gt^2/2
        public static double CalculateVerticalHeight(double v0, double t)
        {
            return v0 * t - _gravityConstData.ConstValue * (t * t) / 2;
        }
        
        // F = Gm1m2/r2
        public static double CalculateUniversalGravitation(double m1, double m2, double r)
        {
            return _gravitationalAttractionConstData.ConstValue * m1 * m2 / (r * r);
        }
        
        // P = m (g + a)
        public static double CalculateHeightOnMoveUp(double m, double a)
        {
            return m * (_gravityConstData.ConstValue + a);
        }
        
        // P = m (g – a)
        public static double CalculateHeightOnMoveDown(double m, double a)
        {
            return m * (_gravityConstData.ConstValue - a);
        }
    }
}