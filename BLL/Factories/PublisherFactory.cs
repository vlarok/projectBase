using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class PublisherFactory
    {
        public PublisherDTO createBasicDTO(Publisher publisher)
        {
            return new PublisherDTO()
            {
                PublisherId = publisher.PublisherId,
                PublisherName=publisher.PublisherName

            };
        }
    }
}
