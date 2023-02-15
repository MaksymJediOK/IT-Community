import { TagsQueryBuilder } from './TagsQueryBuilder'

export const ParametersQueryBuilder = (date, order, tags = [], search) => {
	let baseQuery = '/post/parameters?'
	const extension = `dateFilter=${date}&orderBy=${order}`
	if (tags && search) {
		return `${baseQuery}${TagsQueryBuilder(tags)}&searchString=${search}&${extension}`
	}
	if (tags.length) {
		return `${baseQuery}${TagsQueryBuilder(tags)}&${extension}`
	}
	if (search) {
		return `${baseQuery}searchString=${search}&${extension}`
	}
	if (!tags.length && !search) {
		return `${baseQuery}dateFilter=${date}&orderBy=${order}`
	}
	return baseQuery
}
