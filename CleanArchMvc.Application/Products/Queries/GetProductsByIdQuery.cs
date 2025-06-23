using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries
{
    public class GetProductsByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductsByIdQuery(int id)
        {
            Id = id;
        }
    }
}