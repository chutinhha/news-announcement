﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace NewsAnnouncementWebPart.Model
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Add new entity to list
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>bool</returns>
        /// <exception cref=""></exception>
        bool Add(T entity);

        /// <summary>
        /// Delete existed entity
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>bool</returns>
        /// <exception cref=""></exception>
        bool Delete(int id);

        /// <summary>
        /// Update existed entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>bool</returns>
        /// <exception cref=""></exception>
        bool Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Get all list
        /// </summary>
        /// <returns>SPList</returns>
        SPList Get();
    }
}
