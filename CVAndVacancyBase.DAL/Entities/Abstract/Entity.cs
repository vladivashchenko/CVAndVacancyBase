﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Entities.Abstract

{
    public abstract class Entity
    {
        private int id;

        public int Id { get => id; set => id = value; }
    }
}

