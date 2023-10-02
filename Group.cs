using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cssteamscraping
{
    /*
    CREATE TABLE `groups` (
	`id` VARCHAR(32) NOT NULL COLLATE 'utf8mb4_general_ci',
	`gid` BIGINT(20) NOT NULL DEFAULT -1,
	`name` VARCHAR(128) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`name_indicated` VARCHAR(512) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`name_unicoded` TINYINT(4) NOT NULL DEFAULT -1,
	`abbreviation` VARCHAR(128) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`abbreviation_indicated` VARCHAR(512) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`abbreviation_unicoded` TINYINT(4) NOT NULL DEFAULT -1,
	`url` VARCHAR(128) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`avatar` VARCHAR(256) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`member_count` INT(11) NOT NULL DEFAULT -1,
	`created_at` BIGINT(20) NOT NULL DEFAULT -1,
	`owner` VARCHAR(128) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`owner_steamid` VARCHAR(128) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`last_check` BIGINT(20) NOT NULL DEFAULT unix_timestamp(),
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
;

    */

    internal class Group
    {
        public string id { get; set; } //  The actual id of the group...
        public int gid { get; set; } // The id of the group in the url
        public string name { get; set; } 
		public string name_indicated { get; set; }
		public string name_unicoded { get; set; }
		public string abbreviation { get; set; }
		public string abbreviation_indicated { get; set; }
		public string abbreviation_unicoded { get; set; }
		public string url { get; set; }
		public string avatar { get; set; }
		public int member_count { get; set; }
		public int created_at { get; set; }
		public string owner { get; set; }
		public string owner_steamid { get; set; }
		public int last_check { get; set; }
    }
}
