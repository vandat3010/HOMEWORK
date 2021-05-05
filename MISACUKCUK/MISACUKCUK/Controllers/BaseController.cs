using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACUKCUK.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        #region property

        IBaseRepository<TEntity> _baseRepository;
        IBaseService<TEntity> _baseService;
        string tableName = typeof(TEntity).Name;

        #endregion

        #region constructor
        public BaseController(IBaseService<TEntity> baseService,
            IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        /// <returns>trả về tất cả các bản ghi có trong DB</returns>
        /// CreatedBy: NVDAT
        [HttpGet]

        public IActionResult Get()
        {
            var entities = _baseRepository.GetAll();
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Lấy ra 1 đối tượng theo Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <returns>entity: đối tượng có mã entityId</returns>
        /// CreatedBy: NVDAT (22/04/2021)
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Thêm 1 đối tượng 
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: NVDAT
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var rowAffects = _baseService.Insert(entity);
            if (rowAffects > 0)
            {
                return StatusCode(201, rowAffects);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Sửa 1 đối tượng theo Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns>
        ///     -Thành công: trả về bản ghi đã sửa.
        ///     -Thất bại: NoContent
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TEntity entity)
        {
            //lấy tất cả property của đối tượng
            var properties = typeof(TEntity).GetProperties();
            //Duyệt tất cả property của đối tượng
            foreach (var property in properties)
            {
                //kiểm tra tên của property với entityId thì gán giá trị property = id
                if (property.Name == $"{tableName}Id")
                {
                    property.SetValue(entity, id);
                }
            }
            var rowAffects = _baseService.Update(entity);
            if (rowAffects > 0)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="entityId">Mã đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: NVDAT (22/04/2021)
        [HttpDelete]
        public IActionResult Delete(Guid entityId)
        {
            var rowAffects = _baseService.Delete(entityId);
            if (rowAffects > 0)
            {
                return Ok();

            }
            else
            {
                return NoContent();
            }
        }

        #endregion
    }
}
