﻿using MVC_Project.Models;

namespace E_Commerce.Repository.ReviewRepo
{
    public interface IReviewRepo
    {
        List<Review> getByProduct(int id);
    }
}