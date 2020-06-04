using Core.Entities;
using SharedKernel.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository userRepository)
        {
            if (userRepository.ListAsync<User>().Result.Count() >= 3) return 0;

            userRepository.AddAsync(new User
            {
                UserName = "thientq",
                FullName = "Trần Quốc Thiện",
                Email = "thientq.spkt@gmail.com",
                Gender = true
            }).Wait();
            userRepository.AddAsync(new User
            {
                UserName = "tronghdh",
                FullName = "Hồ Đặng Hữu Trọng",
                Email = "trong.spkt@gmail.com",
                Gender = true
            }).Wait();
            userRepository.AddAsync(new User
            {
                UserName = "vidtt",
                FullName = "Đoàn Thị Tường Vi",
                Email = "tuongvi@gmail.com",
                Gender = true
            }).Wait();

            return userRepository.ListAsync<User>().Result.Count;
        }
    }
}
