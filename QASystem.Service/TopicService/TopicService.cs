﻿using System.Collections.Generic;
using QASystem.Core.Domain;
using QASystem.Core;
using System.Linq;

namespace QASystem.Service.TopicService
{
    public class TopicService : ITopicService
    {
        private IUnitOfWork _uow;
        private IRepository<Topic> _topicRepository;

        public TopicService(IUnitOfWork uow, IRepository<Topic> topicRepository)
        {
            _uow = uow;
            _topicRepository = topicRepository;
        }

        public IEnumerable<Topic> GetAll()
        {
            return _topicRepository.Table.ToList();
        }

        public IEnumerable<Topic> GetHotTopics(int count)
        {
            return _topicRepository.Table.OrderByDescending(u => u.num).Take(count).ToList();
        }
    }


}
