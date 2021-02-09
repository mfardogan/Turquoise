﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Choice
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;

    [Table(name: "choice", Schema = Schamas.SURVEY)]
    public class Choice : ConcurrencyEntity<Guid>, IAggregateRoot
    {
        [Required]
        [Column(name: "name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(name: "code", TypeName = "varchar(3)")]
        public string Code { get; set; }

        [Required]
        [Column(name: "color", TypeName = "varchar(6)")]
        public string Color { get; set; }

        [Column(name: "description", TypeName = "varchar")]
        public string Description { get; set; }

        [Required]
        [Column(name: "choice_group_id")]
        [ForeignKey(name: nameof(ChoiceGroup))]
        public Guid ChoiceGroupId { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual ChoiceGroup ChoiceGroup { get; set; }

    }
}