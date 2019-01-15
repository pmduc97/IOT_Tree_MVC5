namespace IOT_Tree_MVC5.Models
{
    public class TreeItem
    {
        // get ; set
        public long ID_DONVIHANHCHINH { get; set; }
        public string THONGTINCHITIET { get; set; }
        public string TEN_LOAICAYXANH { get; set; }
        public float BANKINHTANLA { get; set; }
        public bool IS_BOVIEN { get; set; }
        public bool IS_PLANT { get; set; }
        public bool IS_ONGNUOC { get; set; }
        public string CAYXANH { get; set; }
        public bool IS_CAOHONVIAHE { get; set; }
        public bool IS_ONGCONG { get; set; }
        public long ID_HINHDANGHO { get; set; }
        public long COUNT { get; set; }
        public string TENCONGTRINHGANNHAT { get; set; }
        public long ID_TINHTRANGSINHTRUONG { get; set; }
        public float LONGITUDE_HOTRONGCAY { get; set; }
        public string NAMBANGIAOCONGTRINH { get; set; }
        public string TEN_PHANLOAIQUYHOACH { get; set; }
        public string IMAGE { get; set; }
        public float DUONGKINHGOC { get; set; }
        public long ID_LOAICAYXANH { get; set; }
        public string TEN_CHUNGLOAICAYXANH { get; set; }
        public float DIENTICHTANLA { get; set; }
        public long ID_CAYXANH { get; set; }
        public long CHIEUCAOVUTNGON { get; set; }
        public string GHICHU { get; set; }
        public long ID_HOTRONGCAY { get; set; }
        public string DUONGPHO { get; set; }
        public long ID_KHUVUCCAYXANH { get; set; }
        public string KHUVUCCAYXANH { get; set; }
        public string NAMTRONGCAY { get; set; }
        public string DONVIHANHCHINH { get; set; }
        public long SOLANCAPNHAT { get; set; }
        public long ID_NHOMNGUYCO { get; set; }
        public bool IS_DAYDIEN { get; set; }
        public string NGAYTAO { get; set; }
        public long ID_LOAIBOVIEN { get; set; }
        public string SONHA { get; set; }
        public long KICHTHUOCHO { get; set; }
        public long DIENTICHHO { get; set; }
        public bool IS_BORAO { get; set; }
        public string TRANGTHAIBOVIEN { get; set; }
        public float LATITUDE_HOTRONGCAY { get; set; }
        public long ENDX { get; set; }
        public long STARTX { get; set; }
        public long ENDY { get; set; }
        public long STARTY { get; set; }
        public string LOAIBOVIEN { get; set; }
        public float KHOANGCACHHOVIA { get; set; }
        public string MA_CAYXANH { get; set; }
        public long ID_TRANGTHAIBOVIEN { get; set; }
        public string TEN_NHOMNGUYCO { get; set; }
        public string HINHDANGHO { get; set; }
        public bool IS_CAPNGAM { get; set; }
        public long ID_NHOMCHUNGLOAI { get; set; }
        public string MA_HOTRONGCAY { get; set; }
        public long ID_PHANLOAIQUYHOACH { get; set; }
        public string TEN_TINHTRANGSINHTRUONG { get; set; }

        // construct
        public TreeItem(long iD_DONVIHANHCHINH, string tHONGTINCHITIET, string tEN_LOAICAYXANH, float bANKINHTANLA, bool iS_BOVIEN, bool iS_PLANT, bool iS_ONGNUOC, string cAYXANH, bool iS_CAOHONVIAHE, bool iS_ONGCONG, long iD_HINHDANGHO, long cOUNT, string tENCONGTRINHGANNHAT, long iD_TINHTRANGSINHTRUONG, float lONGITUDE_HOTRONGCAY, string nAMBANGIAOCONGTRINH, string tEN_PHANLOAIQUYHOACH, string iMAGE, float dUONGKINHGOC, long iD_LOAICAYXANH, string tEN_CHUNGLOAICAYXANH, float dIENTICHTANLA, long iD_CAYXANH, long cHIEUCAOVUTNGON, string gHICHU, long iD_HOTRONGCAY, string dUONGPHO, long iD_KHUVUCCAYXANH, string kHUVUCCAYXANH, string nAMTRONGCAY, string dONVIHANHCHINH, long sOLANCAPNHAT, long iD_NHOMNGUYCO, bool iS_DAYDIEN, string nGAYTAO, long iD_LOAIBOVIEN, string sONHA, long kICHTHUOCHO, long dIENTICHHO, bool iS_BORAO, string tRANGTHAIBOVIEN, float lATITUDE_HOTRONGCAY, long eNDX, long sTARTX, long eNDY, long sTARTY, string lOAIBOVIEN, float kHOANGCACHHOVIA, string mA_CAYXANH, long iD_TRANGTHAIBOVIEN, string tEN_NHOMNGUYCO, string hINHDANGHO, bool iS_CAPNGAM, long iD_NHOMCHUNGLOAI, string mA_HOTRONGCAY, long iD_PHANLOAIQUYHOACH, string tEN_TINHTRANGSINHTRUONG)
        {
            this.ID_DONVIHANHCHINH = iD_DONVIHANHCHINH; this.THONGTINCHITIET = tHONGTINCHITIET; this.TEN_LOAICAYXANH = tEN_LOAICAYXANH; this.BANKINHTANLA = bANKINHTANLA; this.IS_BOVIEN = iS_BOVIEN; this.IS_PLANT = iS_PLANT; this.IS_ONGNUOC = iS_ONGNUOC; this.CAYXANH = cAYXANH; this.IS_CAOHONVIAHE = iS_CAOHONVIAHE; this.IS_ONGCONG = iS_ONGCONG; this.ID_HINHDANGHO = iD_HINHDANGHO; this.COUNT = cOUNT; this.TENCONGTRINHGANNHAT = tENCONGTRINHGANNHAT; this.ID_TINHTRANGSINHTRUONG = iD_TINHTRANGSINHTRUONG; this.LONGITUDE_HOTRONGCAY = lONGITUDE_HOTRONGCAY; this.NAMBANGIAOCONGTRINH = nAMBANGIAOCONGTRINH; this.TEN_PHANLOAIQUYHOACH = tEN_PHANLOAIQUYHOACH; this.IMAGE = iMAGE; this.DUONGKINHGOC = dUONGKINHGOC; this.ID_LOAICAYXANH = iD_LOAICAYXANH; this.TEN_CHUNGLOAICAYXANH = tEN_CHUNGLOAICAYXANH; this.DIENTICHTANLA = dIENTICHTANLA; this.ID_CAYXANH = iD_CAYXANH; this.CHIEUCAOVUTNGON = cHIEUCAOVUTNGON; this.GHICHU = gHICHU; this.ID_HOTRONGCAY = iD_HOTRONGCAY; this.DUONGPHO = dUONGPHO; this.ID_KHUVUCCAYXANH = iD_KHUVUCCAYXANH; this.KHUVUCCAYXANH = kHUVUCCAYXANH; this.NAMTRONGCAY = nAMTRONGCAY; this.DONVIHANHCHINH = dONVIHANHCHINH; this.SOLANCAPNHAT = sOLANCAPNHAT; this.ID_NHOMNGUYCO = iD_NHOMNGUYCO; this.IS_DAYDIEN = iS_DAYDIEN; this.NGAYTAO = nGAYTAO; this.ID_LOAIBOVIEN = iD_LOAIBOVIEN; this.SONHA = sONHA; this.KICHTHUOCHO = kICHTHUOCHO; this.DIENTICHHO = dIENTICHHO; this.IS_BORAO = iS_BORAO; this.TRANGTHAIBOVIEN = tRANGTHAIBOVIEN; this.LATITUDE_HOTRONGCAY = lATITUDE_HOTRONGCAY; this.ENDX = eNDX; this.STARTX = sTARTX; this.ENDY = eNDY; this.STARTY = sTARTY; this.LOAIBOVIEN = lOAIBOVIEN; this.KHOANGCACHHOVIA = kHOANGCACHHOVIA; this.MA_CAYXANH = mA_CAYXANH; this.ID_TRANGTHAIBOVIEN = iD_TRANGTHAIBOVIEN; this.TEN_NHOMNGUYCO = tEN_NHOMNGUYCO; this.HINHDANGHO = hINHDANGHO; this.IS_CAPNGAM = iS_CAPNGAM; this.ID_NHOMCHUNGLOAI = iD_NHOMCHUNGLOAI; this.MA_HOTRONGCAY = mA_HOTRONGCAY; this.ID_PHANLOAIQUYHOACH = iD_PHANLOAIQUYHOACH; this.TEN_TINHTRANGSINHTRUONG = tEN_TINHTRANGSINHTRUONG;
        }
    }
}