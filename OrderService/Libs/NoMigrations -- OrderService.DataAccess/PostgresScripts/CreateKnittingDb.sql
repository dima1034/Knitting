CREATE SCHEMA order_schema AUTHORIZATION admin;

CREATE TYPE OrderStatus AS ENUM ('Created', 'OnHold', 'InProgress', 'Blocked', 'Finished');

create table "orders" (
    id serial PRIMARY KEY
,
    created_at date NOT NULL,
    will_finished_at date NOT NULL,
    finished_at date NULL,
    customer_id integer NOT NULL,
    worker_id integer NULL,
    clothes_id integer NOT NULL
--     status OrderStatus NULL
) WITH (
    OIDS = FALSE
);

ALTER TABLE "orders"
    OWNER to admin;

insert into "orders" (created_at, will_finished_at, customer_id, worker_id, clothes_id)
values ('2017-03-14', '2017-03-15', 0, 0, 0);

select * from "orders";



GRANT ALL ON SCHEMA orderschema TO postgres;
-- ALTER DEFAULT PRIVILEGES IN SCHEMA orderSchema GRANT SELECT ON TABLES TO admin;
-- GRANT ALL PRIVILEGES ON TABLE orderschema.order TO admin;
-- GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA orderschema TO admin;
GRANT SELECT ON ALL TABLES IN SCHEMA orderschema TO PUBLIC;

-- alter user admin
--     superuser
--     createdb
--     createrole
--     replication
--     bypassrls;
