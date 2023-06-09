﻿using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Queries.interfaces;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Queries
{
    /// <summary>
    /// Represents the implementation of restaurant master queries.
    /// </summary>
    public class RestaurantMasterQueries : IRestaurantMasterQueries
    {
        private readonly IRestaurantMasterQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantMasterQueries"/> class.
        /// </summary>
        /// <param name="_repository">The restaurant master query repository.</param>
        public RestaurantMasterQueries(IRestaurantMasterQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Retrieves all restaurant details.
        /// </summary>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Retrieves restaurant details by its ID.
        /// </summary>
        /// <param name="id">The ID of the restaurant.</param>
        /// <returns>A <see cref="Task{JsonResponse}"/> representing the asynchronous operation.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
