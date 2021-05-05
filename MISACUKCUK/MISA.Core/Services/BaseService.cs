using MISA.Core.CustomAttribute;
using MISA.Core.CustomExceptions;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Xóa dữ liệu có Id
        /// </summary>
        /// <param name="entityId">ID bản ghi được chọn</param>
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Lấy bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <returns>Trả về bản ghi cần lấy theo Id</returns>
        public TEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// thêm một bản ghi
        /// </summary>
        /// <param name="entity">thông tin bản ghi cần thêm mới</param>
        /// <returns></returns>
        public int Insert(TEntity entity)
        {
            //Validate data
            Validate(entity);
            CustomValidate(entity);
            return _baseRepository.Insert(entity);
        }
        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">thông tin bản ghi cần cập nhật</param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {
            return _baseRepository.Update(entity);
        }
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Thông tin bản ghi</param>
        private void Validate(TEntity entity)
        {
            //lấy ra tất cả các property của class
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequired), true);
                var maxLengthProperties = property.GetCustomAttributes(typeof(MISAMaxLength), true);

                //Check thông tin khách hàng
                if (requiredProperties.Length > 0)
                {
                    //Lấy giá trị:
                    var propertyValue = property.GetValue(entity);

                    //Kiểm tra giá trị:
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (requiredProperties[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            var msgDefault = Properties.Resources.Msg_Error_Required;
                            var sb = new StringBuilder();
                            var name = (requiredProperties[0] as MISARequired).Name.Length > 0 ? (requiredProperties[0] as MISARequired).Name : property.Name;
                            sb.AppendFormat(msgDefault, name);
                            msgError = sb.ToString();
                        }

                        throw new EntityException(msgError);
                    }
                }
                //Check maxlength
                if (maxLengthProperties.Length > 0)
                {
                    //Get Value
                    var propertyValue = property.GetValue(entity);
                    var maxLength = (maxLengthProperties[0] as MISAMaxLength).MaxLength;
                    //Check Value 
                    if (propertyValue.ToString().Length > maxLength)
                    {
                        var msgError = (maxLengthProperties[0] as MISAMaxLength).MsgError;
                        throw new EntityException(msgError);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CustomValidate(TEntity entity)
        {
        }
    }
}


