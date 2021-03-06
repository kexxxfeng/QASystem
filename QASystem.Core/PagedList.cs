﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace QASystem.Core
{
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// 构造分页集合
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">步长</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            Init(source, pageIndex, pageSize);
        }

        /// <summary>
        /// 构造分页集合
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">步长</param>
        /// <param name="totalCount">数据源总数</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            Init(source, pageIndex, pageSize, totalCount);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="source">资源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">步长</param>
        /// <param name="totalCount">总数</param>
        private void Init(IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (pageSize <= 0)
                throw new ArgumentException("pageSize must be greater than zero");

            TotalCount = totalCount ?? source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            source = totalCount == null ? source.Skip(pageIndex * pageSize).Take(pageSize) : source;
            AddRange(source);
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
