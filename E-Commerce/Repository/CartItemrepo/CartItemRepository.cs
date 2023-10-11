﻿using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace E_Commerce.Repository.CartItemrepo
{
    public class CartItemRepository : ICartItemRepository
    {

        private readonly ECommerceContext context;
        public CartItemRepository(ECommerceContext context)
        {
            this.context = context;
        }

        public void add(CartItem entity)
        {
            context.CartItem.Add(entity);
             
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> getAll(string include = "")
        {
            var query = context.CartItem.AsQueryable();
            if (!String.IsNullOrEmpty(include))
            {
                var includes = include.Split(",");
                foreach (var inc in includes)
                {
                    query = query.Include(inc.Trim());
                }
            }
            return query.ToList();
        }

        public CartItem getById(int id)
        {
            var cart = context.CartItem.FirstOrDefault(p => p.ProductId == id);
            if (cart != null)
                return cart;

            return null;
        }
        public CartItem getByPrdIdUserId(int prdId,int cardId)
        {
            var cart = context.CartItem.FirstOrDefault(p => p.ProductId == prdId && p.CartId == cardId);
            if (cart != null)
                return cart;

            return null;
        }
        public void update(CartItem entity)
        {
            context.CartItem.Update(entity);
         
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}