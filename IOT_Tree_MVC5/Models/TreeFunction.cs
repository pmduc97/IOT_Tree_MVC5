using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IOT_Tree_MVC5.Models
{
    public class TreeFunction
    {
        private ConnectSQL connectSQL = new ConnectSQL();
        private PointFunction pointFunc = new PointFunction();
        public List<TreeLite> getHinhVuong(LoginData loginData, string databaseName, string tableName, PointItem point, double banKinh)
        {

            double latMIN = point.Lat - (banKinh / 110.574);
            double latMAX = point.Lat + (banKinh / 110.574);

            double lngMIN = point.Lng - (banKinh / 111.320 * Math.Cos((banKinh / 110.574)));
            double lngMAX = point.Lng + (banKinh / 111.320 * Math.Cos((banKinh / 110.574)));

            connectSQL.Connect(loginData, databaseName);

            List<TreeLite> listItem = new List<TreeLite>();
            string sqlQuery = "SELECT * FROM " + databaseName + ".dbo." + tableName +
                " WHERE LATITUDE_HOTRONGCAY >= @latMIN AND LATITUDE_HOTRONGCAY <= @latMAX" +
                " AND LONGITUDE_HOTRONGCAY >= @lngMIN AND LONGITUDE_HOTRONGCAY <= @lngMAX";
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            cmd.Parameters.Add(new SqlParameter("latMIN", latMIN));
            cmd.Parameters.Add(new SqlParameter("latMAX", latMAX));
            cmd.Parameters.Add(new SqlParameter("lngMIN", lngMIN));
            cmd.Parameters.Add(new SqlParameter("lngMAX", lngMAX));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                string cayXanh = r["CAYXANH"].ToString();
                double lng = double.Parse(r["LONGITUDE_HOTRONGCAY"].ToString());
                double lat = double.Parse(r["LATITUDE_HOTRONGCAY"].ToString());

                listItem.Add(new TreeLite(cayXanh, lat, lng));
                #region GET Data
                //long iD_DONVIHANHCHINH = long.Parse(r["ID_DONVIHANHCHINH"].ToString());
                //string tHONGTINCHITIET = r["THONGTINCHITIET"].ToString();
                //string tEN_LOAICAYXANH = r["TEN_LOAICAYXANH"].ToString();
                //float bANKINHTANLA = float.Parse(r["BANKINHTANLA"].ToString());
                //bool iS_BOVIEN = bool.Parse(r["IS_BOVIEN"].ToString());// Xu ly du lieu bool
                //bool iS_PLANT = bool.Parse(r["IS_PLANT"].ToString());// Xu ly du lieu bool
                //bool iS_ONGNUOC = bool.Parse(r["IS_ONGNUOC"].ToString());// Xu ly du lieu bool
                //string cAYXANH = r["CAYXANH"].ToString();
                //bool iS_CAOHONVIAHE = bool.Parse(r["IS_CAOHONVIAHE"].ToString());// Xu ly du lieu bool
                //bool iS_ONGCONG = bool.Parse(r["IS_ONGCONG"].ToString());// Xu ly du lieu bool
                //long iD_HINHDANGHO = long.Parse(r["ID_HINHDANGHO"].ToString());
                //long cOUNT = long.Parse(r["COUNT"].ToString());
                //string tENCONGTRINHGANNHAT = r["TENCONGTRINHGANNHAT"].ToString();
                //long iD_TINHTRANGSINHTRUONG = long.Parse(r["ID_TINHTRANGSINHTRUONG"].ToString());
                //double lONGITUDE_HOTRONGCAY = double.Parse(r["LONGITUDE_HOTRONGCAY"].ToString());
                //string nAMBANGIAOCONGTRINH = r["NAMBANGIAOCONGTRINH"].ToString();
                //string tEN_PHANLOAIQUYHOACH = r["TEN_PHANLOAIQUYHOACH"].ToString();
                //string iMAGE = r["IMAGE"].ToString();
                //float dUONGKINHGOC = float.Parse(r["DUONGKINHGOC"].ToString());
                //long iD_LOAICAYXANH = long.Parse(r["ID_LOAICAYXANH"].ToString());
                //string tEN_CHUNGLOAICAYXANH = r["TEN_CHUNGLOAICAYXANH"].ToString();
                //float dIENTICHTANLA = float.Parse(r["DIENTICHTANLA"].ToString());
                //long iD_CAYXANH = long.Parse(r["ID_CAYXANH"].ToString());
                //long cHIEUCAOVUTNGON = long.Parse(r["CHIEUCAOVUTNGON"].ToString());
                //string gHICHU = r["GHICHU"].ToString();
                //long iD_HOTRONGCAY = long.Parse(r["ID_HOTRONGCAY"].ToString());
                //string dUONGPHO = r["DUONGPHO"].ToString();
                //long iD_KHUVUCCAYXANH = long.Parse(r["ID_KHUVUCCAYXANH"].ToString());
                //string kHUVUCCAYXANH = r["KHUVUCCAYXANH"].ToString();
                //string nAMTRONGCAY = r["NAMTRONGCAY"].ToString();
                //string dONVIHANHCHINH = r["DONVIHANHCHINH"].ToString();
                //long sOLANCAPNHAT = long.Parse(r["SOLANCAPNHAT"].ToString());
                //long iD_NHOMNGUYCO = long.Parse(r["ID_NHOMNGUYCO"].ToString());
                //bool iS_DAYDIEN = bool.Parse(r["IS_DAYDIEN"].ToString());// Xu ly du lieu bool
                //string nGAYTAO = r["NGAYTAO"].ToString();
                //long iD_LOAIBOVIEN = long.Parse(r["ID_LOAIBOVIEN"].ToString());
                //string sONHA = r["SONHA"].ToString();
                //long kICHTHUOCHO = long.Parse(r["KICHTHUOCHO"].ToString());
                //long dIENTICHHO = long.Parse(r["DIENTICHHO"].ToString());
                //bool iS_BORAO = bool.Parse(r["IS_BORAO"].ToString());// Xu ly du lieu bool
                //string tRANGTHAIBOVIEN = r["TRANGTHAIBOVIEN"].ToString();
                //double lATITUDE_HOTRONGCAY = float.Parse(r["LATITUDE_HOTRONGCAY"].ToString());
                //long eNDX = long.Parse(r["ENDX"].ToString());
                //long sTARTX = long.Parse(r["STARTX"].ToString());
                //long eNDY = long.Parse(r["ENDY"].ToString());
                //long sTARTY = long.Parse(r["STARTY"].ToString());
                //string lOAIBOVIEN = r["LOAIBOVIEN"].ToString();
                //float kHOANGCACHHOVIA = float.Parse(r["KHOANGCACHHOVIA"].ToString());
                //string mA_CAYXANH = r["MA_CAYXANH"].ToString();
                //long iD_TRANGTHAIBOVIEN = long.Parse(r["ID_TRANGTHAIBOVIEN"].ToString());
                //string tEN_NHOMNGUYCO = r["TEN_NHOMNGUYCO"].ToString();
                //string hINHDANGHO = r["HINHDANGHO"].ToString();
                //bool iS_CAPNGAM = bool.Parse(r["IS_CAPNGAM"].ToString());// Xu ly du lieu bool
                //long iD_NHOMCHUNGLOAI = long.Parse(r["ID_NHOMCHUNGLOAI"].ToString());
                //string mA_HOTRONGCAY = r["MA_HOTRONGCAY"].ToString();
                //long iD_PHANLOAIQUYHOACH = long.Parse(r["ID_PHANLOAIQUYHOACH"].ToString());
                //string tEN_TINHTRANGSINHTRUONG = r["TEN_TINHTRANGSINHTRUONG"].ToString();
                #endregion
                //listItem.Add(new TreeItem(iD_DONVIHANHCHINH, tHONGTINCHITIET, tEN_LOAICAYXANH, bANKINHTANLA, iS_BOVIEN, iS_PLANT, iS_ONGNUOC, cAYXANH, iS_CAOHONVIAHE, iS_ONGCONG, iD_HINHDANGHO, cOUNT, tENCONGTRINHGANNHAT, iD_TINHTRANGSINHTRUONG, lONGITUDE_HOTRONGCAY, nAMBANGIAOCONGTRINH, tEN_PHANLOAIQUYHOACH, iMAGE, dUONGKINHGOC, iD_LOAICAYXANH, tEN_CHUNGLOAICAYXANH, dIENTICHTANLA, iD_CAYXANH, cHIEUCAOVUTNGON, gHICHU, iD_HOTRONGCAY, dUONGPHO, iD_KHUVUCCAYXANH, kHUVUCCAYXANH, nAMTRONGCAY, dONVIHANHCHINH, sOLANCAPNHAT, iD_NHOMNGUYCO, iS_DAYDIEN, nGAYTAO, iD_LOAIBOVIEN, sONHA, kICHTHUOCHO, dIENTICHHO, iS_BORAO, tRANGTHAIBOVIEN, lATITUDE_HOTRONGCAY, eNDX, sTARTX, eNDY, sTARTY, lOAIBOVIEN, kHOANGCACHHOVIA, mA_CAYXANH, iD_TRANGTHAIBOVIEN, tEN_NHOMNGUYCO, hINHDANGHO, iS_CAPNGAM, iD_NHOMCHUNGLOAI, mA_HOTRONGCAY, iD_PHANLOAIQUYHOACH, tEN_TINHTRANGSINHTRUONG));
            }
            r.Close();
            connectSQL.connect.Close();
            return listItem;
        }


        /// <summary>
        /// GET tất cả Item xung quanh hình tròn bán kính và tâm nhập vào (tọa độ blwgs84)
        /// </summary>
        /// <param name="info"></param>
        /// <param name="databaseName"></param>
        /// <param name="tableName"></param>
        /// <param name="point1"></param>
        /// <param name="banKinh"></param>
        /// <returns></returns>
        public List<TreeLite> getHinhTron(LoginData loginData, string databaseName, string tableName, PointItem point1, double banKinh)
        {

            connectSQL.Connect(loginData, databaseName);
            //if (databaseBO.checkRepeatFunc(info) == 0)
            //{
            //    databaseBO.createFunc(info);
            //}
            List<TreeLite> listItem = new List<TreeLite>();
            string sqlQuery = "SELECT * FROM " + databaseName + ".dbo." + tableName;
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                #region GET Data
                //long iD_DONVIHANHCHINH = long.Parse(r["ID_DONVIHANHCHINH"].ToString());
                //string tHONGTINCHITIET = r["THONGTINCHITIET"].ToString();
                //string tEN_LOAICAYXANH = r["TEN_LOAICAYXANH"].ToString();
                //float bANKINHTANLA = float.Parse(r["BANKINHTANLA"].ToString());
                //bool iS_BOVIEN = bool.Parse(r["IS_BOVIEN"].ToString());// Xu ly du lieu bool
                //bool iS_PLANT = bool.Parse(r["IS_PLANT"].ToString());// Xu ly du lieu bool
                //bool iS_ONGNUOC = bool.Parse(r["IS_ONGNUOC"].ToString());// Xu ly du lieu bool
                //string cAYXANH = r["CAYXANH"].ToString();
                //bool iS_CAOHONVIAHE = bool.Parse(r["IS_CAOHONVIAHE"].ToString());// Xu ly du lieu bool
                //bool iS_ONGCONG = bool.Parse(r["IS_ONGCONG"].ToString());// Xu ly du lieu bool
                //long iD_HINHDANGHO = long.Parse(r["ID_HINHDANGHO"].ToString());
                //long cOUNT = long.Parse(r["COUNT"].ToString());
                //string tENCONGTRINHGANNHAT = r["TENCONGTRINHGANNHAT"].ToString();
                //long iD_TINHTRANGSINHTRUONG = long.Parse(r["ID_TINHTRANGSINHTRUONG"].ToString());
                //float lONGITUDE_HOTRONGCAY = float.Parse(r["LONGITUDE_HOTRONGCAY"].ToString());
                //string nAMBANGIAOCONGTRINH = r["NAMBANGIAOCONGTRINH"].ToString();
                //string tEN_PHANLOAIQUYHOACH = r["TEN_PHANLOAIQUYHOACH"].ToString();
                //string iMAGE = r["IMAGE"].ToString();
                //float dUONGKINHGOC = float.Parse(r["DUONGKINHGOC"].ToString());
                //long iD_LOAICAYXANH = long.Parse(r["ID_LOAICAYXANH"].ToString());
                //string tEN_CHUNGLOAICAYXANH = r["TEN_CHUNGLOAICAYXANH"].ToString();
                //float dIENTICHTANLA = float.Parse(r["DIENTICHTANLA"].ToString());
                //long iD_CAYXANH = long.Parse(r["ID_CAYXANH"].ToString());
                //long cHIEUCAOVUTNGON = long.Parse(r["CHIEUCAOVUTNGON"].ToString());
                //string gHICHU = r["GHICHU"].ToString();
                //long iD_HOTRONGCAY = long.Parse(r["ID_HOTRONGCAY"].ToString());
                //string dUONGPHO = r["DUONGPHO"].ToString();
                //long iD_KHUVUCCAYXANH = long.Parse(r["ID_KHUVUCCAYXANH"].ToString());
                //string kHUVUCCAYXANH = r["KHUVUCCAYXANH"].ToString();
                //string nAMTRONGCAY = r["NAMTRONGCAY"].ToString();
                //string dONVIHANHCHINH = r["DONVIHANHCHINH"].ToString();
                //long sOLANCAPNHAT = long.Parse(r["SOLANCAPNHAT"].ToString());
                //long iD_NHOMNGUYCO = long.Parse(r["ID_NHOMNGUYCO"].ToString());
                //bool iS_DAYDIEN = bool.Parse(r["IS_DAYDIEN"].ToString());// Xu ly du lieu bool
                //string nGAYTAO = r["NGAYTAO"].ToString();
                //long iD_LOAIBOVIEN = long.Parse(r["ID_LOAIBOVIEN"].ToString());
                //string sONHA = r["SONHA"].ToString();
                //long kICHTHUOCHO = long.Parse(r["KICHTHUOCHO"].ToString());
                //long dIENTICHHO = long.Parse(r["DIENTICHHO"].ToString());
                //bool iS_BORAO = bool.Parse(r["IS_BORAO"].ToString());// Xu ly du lieu bool
                //string tRANGTHAIBOVIEN = r["TRANGTHAIBOVIEN"].ToString();
                //float lATITUDE_HOTRONGCAY = float.Parse(r["LATITUDE_HOTRONGCAY"].ToString());
                //long eNDX = long.Parse(r["ENDX"].ToString());
                //long sTARTX = long.Parse(r["STARTX"].ToString());
                //long eNDY = long.Parse(r["ENDY"].ToString());
                //long sTARTY = long.Parse(r["STARTY"].ToString());
                //string lOAIBOVIEN = r["LOAIBOVIEN"].ToString();
                //float kHOANGCACHHOVIA = float.Parse(r["KHOANGCACHHOVIA"].ToString());
                //string mA_CAYXANH = r["MA_CAYXANH"].ToString();
                //long iD_TRANGTHAIBOVIEN = long.Parse(r["ID_TRANGTHAIBOVIEN"].ToString());
                //string tEN_NHOMNGUYCO = r["TEN_NHOMNGUYCO"].ToString();
                //string hINHDANGHO = r["HINHDANGHO"].ToString();
                //bool iS_CAPNGAM = bool.Parse(r["IS_CAPNGAM"].ToString());// Xu ly du lieu bool
                //long iD_NHOMCHUNGLOAI = long.Parse(r["ID_NHOMCHUNGLOAI"].ToString());
                //string mA_HOTRONGCAY = r["MA_HOTRONGCAY"].ToString();
                //long iD_PHANLOAIQUYHOACH = long.Parse(r["ID_PHANLOAIQUYHOACH"].ToString());
                //string tEN_TINHTRANGSINHTRUONG = r["TEN_TINHTRANGSINHTRUONG"].ToString();
                #endregion
                string cayXanh = r["CAYXANH"].ToString();
                double lng = double.Parse(r["LONGITUDE_HOTRONGCAY"].ToString());
                double lat = double.Parse(r["LATITUDE_HOTRONGCAY"].ToString());

                PointItem point2 = new PointItem(lat, lng);
                if(pointFunc.tinhKhoangCachHaiDiem(point1,point2) <= banKinh)
                {
                listItem.Add(new TreeLite(cayXanh,lat,lng));
                }
            }
            r.Close();
            connectSQL.connect.Close();
            return listItem;
        }
    }
}