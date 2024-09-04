﻿using System;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Interfaces.Repositories;

namespace Notebook.Domain.Entity
{
    public class UserToken : IEntityId<long>
    {
        public long Id { get; set; }
        
        public string RefreshToken { get; set; }
        
        public DateTime RefreshTokenExpireTime { get; set; }
        
        public User User { get; set; }
        
        public long UserId { get; set; }
    }
}