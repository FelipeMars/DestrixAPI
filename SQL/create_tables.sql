CREATE TABLE public.users (
    user_id SERIAL PRIMARY KEY NOT NULL,
    created_at TIMESTAMP NOT NULL,
    changed_at TIMESTAMP,
    active BOOLEAN NOT NULL,
    name VARCHAR(128) NOT NULL,
    email VARCHAR(64) NOT NULL,
    password VARCHAR(256) NOT NULL
);

CREATE TABLE public.transactions (
    transaction_id SERIAL PRIMARY KEY NOT NULL,
    created_at TIMESTAMP NOT NULL,
    changed_at TIMESTAMP,
    transaction_date TIMESTAMP NOT NULL,
    transaction_reference UUID UNIQUE NOT NULL,
    description VARCHAR(256),
    value DECIMAL(32,2) NOT NULL,
    user_id INT NOT NULL REFERENCES public.users(user_id), 
    transaction_type INT NOT NULL
);

CREATE TABLE public.types (
    type_id SERIAL PRIMARY KEY NOT NULL,
    "table" VARCHAR(24) NOT NULL,
    description VARCHAR(40) NOT NULL,
    "value" INT NOT NULL
);

CREATE TABLE public.user_categories (
    user_category_id SERIAL PRIMARY KEY NOT NULL,
	createdAt TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    modfiedAt TIMESTAMP(3),
    active BOOLEAN NOT NULL,
    user_id INT NOT NULL REFERENCES public.users(user_id),
	"name" VARCHAR(24) NOT NULL,
    description VARCHAR(256) NOT NULL,
	color VARCHAR(7) NOT NULL
);

CREATE TABLE public.transaction_categories (
    transaction_category_id SERIAL PRIMARY KEY NOT NULL,
    transaction_id INT NOT NULL REFERENCES public.transactions (transaction_id),
    user_category_id INT NOT NULL REFERENCES public.user_categories (user_category_id)
);

