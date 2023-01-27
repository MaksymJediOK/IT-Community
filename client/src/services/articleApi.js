import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const articleApi = createApi({
	reducerPath: '@article',
	tagTypes: ['Articles'],
	baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7230/api' }),
	endpoints: (build) => ({
		getArticlesList: build.query({
			query: (arg) => '/post',
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
