﻿using Movie.Application.Interfaces.Repositories;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Domain.Entities.Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext context) : base(context)
        {
        }
    }
}
