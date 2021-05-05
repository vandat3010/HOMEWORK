using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Trả về dữ liệu bản ghi</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Lấy toàn bộ bản ghi có id là entityId
        /// </summary>
        /// <param name="entityId">id đối tượng</param>
        /// <returns>Trả về bản ghi có id là entityId</returns>
        TEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns>Thêm thành công bản ghi mới hay không</returns>
        int Insert(TEntity entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns>Cập nhật bản ghi thành công hay không</returns>
        int Update(TEntity entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">id đối tượng</param>
        /// <returns>Xóa bản ghi thành công hay không</returns>
        int Delete(Guid entityId);
    }
}
