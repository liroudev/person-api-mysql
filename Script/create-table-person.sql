CREATE TABLE `person` (
	`id` BIGINT(19) NOT NULL AUTO_INCREMENT,
	`first_name` VARCHAR(250) NOT NULL DEFAULT '' COLLATE 'utf8_general_ci',
	`last_name` VARCHAR(250) NOT NULL DEFAULT '' COLLATE 'utf8_general_ci',
	`adress` VARCHAR(250) NOT NULL DEFAULT '' COLLATE 'utf8_general_ci',
	`gender` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8_general_ci',
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;