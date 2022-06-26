infra:
	@docker-compose up -d mongo
	@docker-compose up -d mountebank

clean:
	@docker-compose down