USE drcloud_main;

CREATE TABLE 	__migrations_history		(
	migration_id varchar(128) NOT NULL, PRIMARY KEY(`migration_id`),		
	migration_time datetime NOT NULL DEFAULT NOW()
			);
            
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S003_00000000_init');