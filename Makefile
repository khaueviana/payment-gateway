.PHONY: build infra run clean

build:
	@docker-compose up --build --no-start

run: build infra
	@docker-compose up -d service

infra:
	@docker-compose up -d mongo
	@docker-compose up -d mountebank

clean:
	@docker-compose down