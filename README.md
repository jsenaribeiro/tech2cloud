# tech2cloud

## Evoluations

* create a shared IRepository
* create marker DDD interfaces (IEntity, IAggregate)
* added some implicity validation (price > 0, required, etc)
* abstract repository for basic CRUD

## Changings

* fix GetUserQuery to GetUserQuery (CQRS)
* extract audit fields to BaseEntity
* service locator pattern for DI (better testing)
* BastEntity marked as abstract
* missing mapper between GetUserResult -> GetUserResponse
* PaginatedList -> PageList -> DDD -> {  data: }  // AutoMapper not works with :List<T>

## Suggestions

* change Domain to DDD module pattern (DDD namespace)
* maybe sort is best for filter, not _order, order could mean buy request
* centralize all message error as constants for reuse and tests

## Questions

* why double validator (GetUserRequestValidator + GetUserValidator)
