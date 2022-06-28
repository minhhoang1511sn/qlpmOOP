using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class TaikhoanBul
    {
        private readonly TaikhoanDal _taikhoanDal = new TaikhoanDal();

        public DataTable load_taikhoan()
        {
            return _taikhoanDal.load_taikhoan();
        }

        public int insert_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            return _taikhoanDal.insert_taikhoan(taikhoanPublic);
        }

        public int update_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            return _taikhoanDal.update_taikhoan(taikhoanPublic);
        }

        public int delete_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            return _taikhoanDal.delete_taikhoan(taikhoanPublic);
        }

        public int check_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            return _taikhoanDal.check_taikhoan(taikhoanPublic);
        }

        public DataTable get_tenvaquyen_taikhoan(TAIKHOAN_PUBLIC taikhoanPublic)
        {
            return _taikhoanDal.get_tenvaquyen_taikhoan(taikhoanPublic);
        }
    }
}