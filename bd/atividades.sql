BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "atividades" (
	"id"	INTEGER,
	"nome"	varchar(50),
	"descricao"	varchar(100),
	"prazo"	date,
	"situacao"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);
INSERT INTO "atividades" VALUES (1,'Daniel','oi','2023-10-5',123);
INSERT INTO "atividades" VALUES (2,'lucas','teste','2023-10-25 00:00:00',2);
INSERT INTO "atividades" VALUES (3,'lucas','teste 2','2023-10-25 20:43:32.6410774',1);
INSERT INTO "atividades" VALUES (4,'lucas','teste 3','2023-10-31 00:00:00',2);
INSERT INTO "atividades" VALUES (5,'','','2023-10-31 00:00:00',1);
INSERT INTO "atividades" VALUES (6,'lucas','teste 2','2023-10-25 00:00:00',2);
COMMIT;
