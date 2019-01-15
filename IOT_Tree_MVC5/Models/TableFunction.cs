using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace IOT_Tree_MVC5.Models
{
    public class TableFunction
    {
        private ConnectSQL connectSQL = new ConnectSQL();
        private PointFunction pointFunc = new PointFunction();

        public List<TableItem> getAllTableFromDatabase(LoginData loginData,string databaseName)
        {
            List<TableItem> listTableItem = new List<TableItem>();
            connectSQL.Connect(loginData, databaseName);
            string sqlQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'  ORDER BY TABLE_NAME";
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                listTableItem.Add(new TableItem(r["TABLE_NAME"].ToString()));
            }
            r.Close();
            connectSQL.connect.Close();
            return listTableItem;
        }

        public int checkRepeatTable(LoginData loginData,string databaseName,string tableName)
        {
            List<TableItem> listAllTableFromDatabase = getAllTableFromDatabase(loginData, databaseName);
            var listFindTableWithTableName = listAllTableFromDatabase.Where(p => p.TableName.Equals(tableName));
            if(listFindTableWithTableName.Count() == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string createTable(LoginData loginData,string databaseName,string tableName)
        {
            if(checkRepeatTable(loginData,databaseName,tableName) == 1)
            {
                return "Đã tồn tại table <" + tableName + "> trong database";
            }
            connectSQL.Connect(loginData, databaseName);
            #region Table Struct
            string sqlQuery = "CREATE TABLE " + tableName + " ("
                + "ID_DONVIHANHCHINH bigINT,"
                + "THONGTINCHITIET NVARCHAR(MAX),"
                + "TEN_LOAICAYXANH NVARCHAR(100) NOT NULL,"
                + "BANKINHTANLA FLOAT NOT NULL,"
                + "IS_BOVIEN BIT NOT NULL,"
                + "IS_PLANT BIT NOT NULL,"
                + "IS_ONGNUOC BIT NOT NULL,"
                + "CAYXANH NVARCHAR(100) NOT NULL,"
                + "IS_CAOHONVIAHE BIT NOT NULL,"
                + "IS_ONGCONG BIT NOT NULL,"
                + "ID_HINHDANGHO BIGINT NOT NULL,"
                + "COUNT BIGINT NOT NULL,"
                + "TENCONGTRINHGANNHAT NVARCHAR(MAX),"
                + "ID_TINHTRANGSINHTRUONG BIGINT NOT NULL,"
                + "LONGITUDE_HOTRONGCAY FLOAT NOT NULL,"
                + "NAMBANGIAOCONGTRINH NVARCHAR(50) NOT NULL,"
                + "TEN_PHANLOAIQUYHOACH NVARCHAR(MAX) NOT NULL,"
                + "IMAGE NVARCHAR(MAX),"
                + "DUONGKINHGOC FLOAT NOT NULL,"
                + "ID_LOAICAYXANH BIGINT NOT NULL,"
                + "TEN_CHUNGLOAICAYXANH NVARCHAR(MAX) NOT NULL,"
                + "DIENTICHTANLA FLOAT NOT NULL,"
                + "ID_CAYXANH BIGINT NOT NULL,"
                + "CHIEUCAOVUTNGON BIGINT NOT NULL,"
                + "GHICHU NVARCHAR(MAX) NOT NULL,"
                + "ID_HOTRONGCAY BIGINT NOT NULL,"
                + "DUONGPHO NVARCHAR(MAX) NOT NULL,"
                + "ID_KHUVUCCAYXANH BIGINT NOT NULL,"
                + "KHUVUCCAYXANH NVARCHAR(MAX),"
                + "NAMTRONGCAY NVARCHAR(50) NOT NULL,"
                + "DONVIHANHCHINH NVARCHAR(MAX),"
                + "SOLANCAPNHAT BIGINT NOT NULL,"
                + "ID_NHOMNGUYCO BIGINT NOT NULL,"
                + "IS_DAYDIEN BIT NOT NULL,"
                + "NGAYTAO NVARCHAR(50) NOT NULL,"
                + "ID_LOAIBOVIEN BIGINT NOT NULL,"
                + "SONHA NVARCHAR(MAX) NOT NULL,"
                + "KICHTHUOCHO BIGINT NOT NULL,"
                + "DIENTICHHO BIGINT NOT NULL,"
                + "IS_BORAO BIT NOT NULL,"
                + "TRANGTHAIBOVIEN NVARCHAR(MAX),"
                + "LATITUDE_HOTRONGCAY FLOAT NOT NULL,"
                + "ENDX BIGINT NOT NULL,"
                + "STARTX BIGINT NOT NULL,"
                + "ENDY BIGINT NOT NULL,"
                + "STARTY BIGINT NOT NULL,"
                + "LOAIBOVIEN NVARCHAR(100) NOT NULL,"
                + "KHOANGCACHHOVIA FLOAT NOT NULL,"
                + "MA_CAYXANH NVARCHAR(100) NOT NULL,"
                + "ID_TRANGTHAIBOVIEN BIGINT NOT NULL,"
                + "TEN_NHOMNGUYCO NVARCHAR(MAX),"
                + "HINHDANGHO NVARCHAR(100) NOT NULL,"
                + "IS_CAPNGAM BIT NOT NULL,"
                + "ID_NHOMCHUNGLOAI BIGINT NOT NULL,"
                + "MA_HOTRONGCAY NVARCHAR(MAX) NOT NULL,"
                + "ID_PHANLOAIQUYHOACH BIGINT NOT NULL,"
                + "TEN_TINHTRANGSINHTRUONG NVARCHAR(MAX) NOT NULL"
                +
                ")";
            #endregion
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            int i = cmd.ExecuteNonQuery();
            connectSQL.connect.Close();
            if(i == -1)
            {
                return "Tạo table <" + tableName + "> thành công";
            }
            return "Có lỗi. Vui lòng thử lại";
        }

        public int insertDataToTable(LoginData loginData, string databaseName, string tableName,List<TreeItem> listTree)
        {
            connectSQL.Connect(loginData, databaseName);
            int sumRow = 0;
            int i;
            string sqlQuery = "";
            SqlCommand cmd = null;
            foreach (var item in listTree)
            {
                sqlQuery = "INSERT INTO " + tableName + "( ID_DONVIHANHCHINH,THONGTINCHITIET,TEN_LOAICAYXANH,BANKINHTANLA,IS_BOVIEN,IS_PLANT,IS_ONGNUOC,CAYXANH,IS_CAOHONVIAHE,IS_ONGCONG,ID_HINHDANGHO,COUNT,TENCONGTRINHGANNHAT,ID_TINHTRANGSINHTRUONG,LONGITUDE_HOTRONGCAY,NAMBANGIAOCONGTRINH,TEN_PHANLOAIQUYHOACH,IMAGE,DUONGKINHGOC,ID_LOAICAYXANH,TEN_CHUNGLOAICAYXANH,DIENTICHTANLA,ID_CAYXANH,CHIEUCAOVUTNGON,GHICHU,ID_HOTRONGCAY,DUONGPHO,ID_KHUVUCCAYXANH,KHUVUCCAYXANH,NAMTRONGCAY,DONVIHANHCHINH,SOLANCAPNHAT,ID_NHOMNGUYCO,IS_DAYDIEN,NGAYTAO,ID_LOAIBOVIEN,SONHA,KICHTHUOCHO,DIENTICHHO,IS_BORAO,TRANGTHAIBOVIEN,LATITUDE_HOTRONGCAY,ENDX,STARTX,ENDY,STARTY,LOAIBOVIEN,KHOANGCACHHOVIA,MA_CAYXANH,ID_TRANGTHAIBOVIEN,TEN_NHOMNGUYCO,HINHDANGHO,IS_CAPNGAM,ID_NHOMCHUNGLOAI,MA_HOTRONGCAY,ID_PHANLOAIQUYHOACH,TEN_TINHTRANGSINHTRUONG )"
                            + " VALUES "
                            + "( @iD_DONVIHANHCHINH,@tHONGTINCHITIET,@tEN_LOAICAYXANH,@bANKINHTANLA,@iS_BOVIEN,@iS_PLANT,@iS_ONGNUOC,@cAYXANH,@iS_CAOHONVIAHE,@iS_ONGCONG,@iD_HINHDANGHO,@cOUNT,@tENCONGTRINHGANNHAT,@iD_TINHTRANGSINHTRUONG,@lONGITUDE_HOTRONGCAY,@nAMBANGIAOCONGTRINH,@tEN_PHANLOAIQUYHOACH,@iMAGE,@dUONGKINHGOC,@iD_LOAICAYXANH,@tEN_CHUNGLOAICAYXANH,@dIENTICHTANLA,@iD_CAYXANH,@cHIEUCAOVUTNGON,@gHICHU,@iD_HOTRONGCAY,@dUONGPHO,@iD_KHUVUCCAYXANH,@kHUVUCCAYXANH,@nAMTRONGCAY,@dONVIHANHCHINH,@sOLANCAPNHAT,@iD_NHOMNGUYCO,@iS_DAYDIEN,@nGAYTAO,@iD_LOAIBOVIEN,@sONHA,@kICHTHUOCHO,@dIENTICHHO,@iS_BORAO,@tRANGTHAIBOVIEN,@lATITUDE_HOTRONGCAY,@eNDX,@sTARTX,@eNDY,@sTARTY,@lOAIBOVIEN,@kHOANGCACHHOVIA,@mA_CAYXANH,@iD_TRANGTHAIBOVIEN,@tEN_NHOMNGUYCO,@hINHDANGHO,@iS_CAPNGAM,@iD_NHOMCHUNGLOAI,@mA_HOTRONGCAY,@iD_PHANLOAIQUYHOACH,@tEN_TINHTRANGSINHTRUONG)";
                cmd = new SqlCommand(sqlQuery, connectSQL.connect);
                PointItem point = pointFunc.vn2000_2_blwgs84(item.LATITUDE_HOTRONGCAY, item.LONGITUDE_HOTRONGCAY);
                #region Add Parameters
                cmd.Parameters.Add(new SqlParameter("iD_DONVIHANHCHINH", item.ID_DONVIHANHCHINH));
                cmd.Parameters.Add(new SqlParameter("tHONGTINCHITIET", item.THONGTINCHITIET));
                cmd.Parameters.Add(new SqlParameter("tEN_LOAICAYXANH", item.TEN_LOAICAYXANH));
                cmd.Parameters.Add(new SqlParameter("bANKINHTANLA", item.BANKINHTANLA));
                cmd.Parameters.Add(new SqlParameter("iS_BOVIEN", item.IS_BOVIEN));
                cmd.Parameters.Add(new SqlParameter("iS_PLANT", item.IS_PLANT));
                cmd.Parameters.Add(new SqlParameter("iS_ONGNUOC", item.IS_ONGNUOC));
                cmd.Parameters.Add(new SqlParameter("cAYXANH", item.CAYXANH));
                cmd.Parameters.Add(new SqlParameter("iS_CAOHONVIAHE", item.IS_CAOHONVIAHE));
                cmd.Parameters.Add(new SqlParameter("iS_ONGCONG", item.IS_ONGCONG));
                cmd.Parameters.Add(new SqlParameter("iD_HINHDANGHO", item.ID_HINHDANGHO));
                cmd.Parameters.Add(new SqlParameter("cOUNT", item.COUNT));
                cmd.Parameters.Add(new SqlParameter("tENCONGTRINHGANNHAT", item.TENCONGTRINHGANNHAT));
                cmd.Parameters.Add(new SqlParameter("iD_TINHTRANGSINHTRUONG", item.ID_TINHTRANGSINHTRUONG));
                cmd.Parameters.Add(new SqlParameter("lONGITUDE_HOTRONGCAY", point.Lng));
                cmd.Parameters.Add(new SqlParameter("nAMBANGIAOCONGTRINH", item.NAMBANGIAOCONGTRINH));
                cmd.Parameters.Add(new SqlParameter("tEN_PHANLOAIQUYHOACH", item.TEN_PHANLOAIQUYHOACH));
                cmd.Parameters.Add(new SqlParameter("iMAGE", item.IMAGE));
                cmd.Parameters.Add(new SqlParameter("dUONGKINHGOC", item.DUONGKINHGOC));
                cmd.Parameters.Add(new SqlParameter("iD_LOAICAYXANH", item.ID_LOAICAYXANH));
                cmd.Parameters.Add(new SqlParameter("tEN_CHUNGLOAICAYXANH", item.TEN_CHUNGLOAICAYXANH));
                cmd.Parameters.Add(new SqlParameter("dIENTICHTANLA", item.DIENTICHTANLA));
                cmd.Parameters.Add(new SqlParameter("iD_CAYXANH", item.ID_CAYXANH));
                cmd.Parameters.Add(new SqlParameter("cHIEUCAOVUTNGON", item.CHIEUCAOVUTNGON));
                cmd.Parameters.Add(new SqlParameter("gHICHU", item.GHICHU));
                cmd.Parameters.Add(new SqlParameter("iD_HOTRONGCAY", item.ID_HOTRONGCAY));
                cmd.Parameters.Add(new SqlParameter("dUONGPHO", item.DUONGPHO));
                cmd.Parameters.Add(new SqlParameter("iD_KHUVUCCAYXANH", item.ID_KHUVUCCAYXANH));
                cmd.Parameters.Add(new SqlParameter("kHUVUCCAYXANH", item.KHUVUCCAYXANH));
                cmd.Parameters.Add(new SqlParameter("nAMTRONGCAY", item.NAMTRONGCAY));
                cmd.Parameters.Add(new SqlParameter("dONVIHANHCHINH", item.DONVIHANHCHINH));
                cmd.Parameters.Add(new SqlParameter("sOLANCAPNHAT", item.SOLANCAPNHAT));
                cmd.Parameters.Add(new SqlParameter("iD_NHOMNGUYCO", item.ID_NHOMNGUYCO));
                cmd.Parameters.Add(new SqlParameter("iS_DAYDIEN", item.IS_DAYDIEN));
                cmd.Parameters.Add(new SqlParameter("nGAYTAO", item.NGAYTAO));
                cmd.Parameters.Add(new SqlParameter("iD_LOAIBOVIEN", item.ID_LOAIBOVIEN));
                cmd.Parameters.Add(new SqlParameter("sONHA", item.SONHA));
                cmd.Parameters.Add(new SqlParameter("kICHTHUOCHO", item.KICHTHUOCHO));
                cmd.Parameters.Add(new SqlParameter("dIENTICHHO", item.DIENTICHHO));
                cmd.Parameters.Add(new SqlParameter("iS_BORAO", item.IS_BORAO));
                cmd.Parameters.Add(new SqlParameter("tRANGTHAIBOVIEN", item.TRANGTHAIBOVIEN));
                cmd.Parameters.Add(new SqlParameter("lATITUDE_HOTRONGCAY", point.Lat));
                cmd.Parameters.Add(new SqlParameter("eNDX", item.ENDX));
                cmd.Parameters.Add(new SqlParameter("sTARTX", item.STARTX));
                cmd.Parameters.Add(new SqlParameter("eNDY", item.ENDY));
                cmd.Parameters.Add(new SqlParameter("sTARTY", item.STARTY));
                cmd.Parameters.Add(new SqlParameter("lOAIBOVIEN", item.LOAIBOVIEN));
                cmd.Parameters.Add(new SqlParameter("kHOANGCACHHOVIA", item.KHOANGCACHHOVIA));
                cmd.Parameters.Add(new SqlParameter("mA_CAYXANH", item.MA_CAYXANH));
                cmd.Parameters.Add(new SqlParameter("iD_TRANGTHAIBOVIEN", item.ID_TRANGTHAIBOVIEN));
                cmd.Parameters.Add(new SqlParameter("tEN_NHOMNGUYCO", item.TEN_NHOMNGUYCO));
                cmd.Parameters.Add(new SqlParameter("hINHDANGHO", item.HINHDANGHO));
                cmd.Parameters.Add(new SqlParameter("iS_CAPNGAM", item.IS_CAPNGAM));
                cmd.Parameters.Add(new SqlParameter("iD_NHOMCHUNGLOAI", item.ID_NHOMCHUNGLOAI));
                cmd.Parameters.Add(new SqlParameter("mA_HOTRONGCAY", item.MA_HOTRONGCAY));
                cmd.Parameters.Add(new SqlParameter("iD_PHANLOAIQUYHOACH", item.ID_PHANLOAIQUYHOACH));
                cmd.Parameters.Add(new SqlParameter("tEN_TINHTRANGSINHTRUONG", item.TEN_TINHTRANGSINHTRUONG));
                #endregion
                i = cmd.ExecuteNonQuery();
                sumRow += i;
            }
            return sumRow;
        }

        public string readAllTextFromFile(string link)
        {
            string txt = File.ReadAllText(link);
            return txt;
        }

        public List<TreeItem> jsonToObject(string jsonString)
        {
            List<TreeItem> listItem = new List<TreeItem>();
            listItem = JsonConvert.DeserializeObject<List<TreeItem>>(jsonString);
            return listItem;
        }

        public List<TreeItem> List_vn2000_To_blwgs84(List<TreeItem> list)
        {
            PointItem point = null;
            foreach (var item in list)
            {
                point = pointFunc.vn2000_2_blwgs84(item.LATITUDE_HOTRONGCAY, item.LONGITUDE_HOTRONGCAY);
                //float x = float.Parse(point.Lat.ToString());
                //float y = float.Parse(point.Lng.ToString());
                item.LATITUDE_HOTRONGCAY = (float)point.Lat;
                item.LONGITUDE_HOTRONGCAY = (float)point.Lng;
            }
            return list;
        }

    }
}