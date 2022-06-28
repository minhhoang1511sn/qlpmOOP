using System.Data;
using PUBLIC;

namespace DAL
{
    public class TaikhoanDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_taikhoan()
        {
            var sql = @"LOAD_TAIKHOAN";
            return _ketnoi.Load_Data(sql);
        }

        public DataTable get_tenvaquyen_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TENTK";
            name[1] = "@MATKHAU";
            values[0] = taikhoanPublic.TENTK;
            values[1] = taikhoanPublic.MATKHAU;
            var sql = "GET_TENVAQUYEN_TAIKHOAN";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public int insert_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            var parameter = 4;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TENTK";
            name[1] = "@MATKHAU";
            name[2] = "@QUYEN";
            name[3] = "@IDNV";
            values[0] = taikhoanPublic.TENTK;
            values[1] = taikhoanPublic.MATKHAU;
            values[2] = taikhoanPublic.QUYEN;
            values[3] = taikhoanPublic.IDNV;
            var sql = "INSERT_TAIKHOAN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int update_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            var parameter = 4;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TENTK";
            name[1] = "@MATKHAU";
            name[2] = "@QUYEN";
            name[3] = "@IDNV";
            values[0] = taikhoanPublic.TENTK;
            values[1] = taikhoanPublic.MATKHAU;
            values[2] = taikhoanPublic.QUYEN;
            values[3] = taikhoanPublic.IDNV;
            var sql = @"UPDATE_TAIKHOAN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TENTK";
            values[0] = taikhoanPublic.TENTK;
            var sql = @"DELETE_TAIKHOAN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int check_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TENTK";
            name[1] = "@MATKHAU";
            values[0] = taikhoanPublic.TENTK;
            values[1] = taikhoanPublic.MATKHAU;
            var sql = @"CHECK_TAIKHOAN";
            return _ketnoi.ReturnValueIntWithParameter(sql, name, values, parameter);
        }
    }
}