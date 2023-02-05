import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { TagsQueryBuilder } from '../utils/TagsQueryBuilder'

export const articleApi = createApi({
	reducerPath: '@article',
	tagTypes: ['Articles'],
	baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7230/api' }),
	endpoints: (build) => ({
		getArticlesList: build.query({
			query: ({ filter, sort, tags }) => {
				if (filter) return `/post/parameters?dateFilter=${filter}`
				if (sort) return `/post/parameters?orderBy=${sort}`
				if (filter && sort) return `/post/parameters?dateFilter=${filter}&orderBy=${sort}`
				if (tags) return TagsQueryBuilder(tags)
				if (tags && filter) return `${TagsQueryBuilder(tags)}&dateFilter=${filter}`
				if (tags && filter && sort)
					return `${TagsQueryBuilder(tags)}&dateFilter=${filter}&orderBy=${sort}`

				return '/post/parameters'
			},
			providesTags: (result) =>
				result
					? [
							...result.map(({ id }) => ({ type: 'Articles', id })),
							{ type: 'Articles', id: 'LIST' },
					  ]
					: [{ type: 'Articles', id: 'LIST' }],
		}),
		getSingleArticle: build.query({
			query: (articleId = 1) => `/post/${articleId}`,
		}),
	}),
})

export const { useGetArticlesListQuery, useGetSingleArticleQuery } = articleApi
