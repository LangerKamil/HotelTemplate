﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HotelApplication.Models;
using HotelApplication.DTOs;

namespace HotelApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Gender, GenderDTO>();
            Mapper.CreateMap<Room, RoomDTO>();
            Mapper.CreateMap<RoomType, RoomTypeDTO>();
            Mapper.CreateMap<RoomStatus, RoomStatusDTO>();

            // DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<GenderDTO, Gender>();
            Mapper.CreateMap<RoomDTO, Room>();
            Mapper.CreateMap<RoomTypeDTO, RoomType>();
            Mapper.CreateMap<RoomStatusDTO, RoomStatus>();

            // Domain
            Mapper.CreateMap<Room, Room>();
            Mapper.CreateMap<Customer, Customer>();

        }
    }
}