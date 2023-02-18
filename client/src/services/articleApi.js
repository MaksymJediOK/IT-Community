import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ParametersQueryBuilder } from '../utils/ParametersQueryBuilder'

const baseQuery = fetchBaseQuery({
	baseUrl: 'https://localhost:7230/api',
	prepareHeaders: (headers) => {
		const token = localStorage.getItem('token')
		if (token) {
			headers.set('Authorization', `Bearer ${token}`)
		}
		return headers
	},
})

export const articleApi = createApi({
	reducerPath: '@article',
	tagTypes: ['Articles'],
	baseQuery: baseQuery,
	endpoints: (build) => ({
		getArticlesList: build.query({
			query: ({ filter, sort, tags, search }) => {
				return ParametersQueryBuilder(filter, sort, tags, search)
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
		createArticle: build.mutation({
			query: (article) => ({
				url: '/post',
				method: 'POST',
				body: article,
			}),
		}),
	}),
})

export const { useGetArticlesListQuery, useGetSingleArticleQuery, useCreateArticleMutation } = articleApi
