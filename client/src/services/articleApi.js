import { createApi } from '@reduxjs/toolkit/query/react'
import { ParametersQueryBuilder } from '../utils/ParametersQueryBuilder'
import { baseQuery } from './baseQuery';


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
			invalidatesTags: [{ type: 'Articles', id: 'LIST' }],
		}),
		EditArticle: build.mutation({
			query: ({ id, editBody }) => ({
				url: `/post/${id}`,
				method: 'PUT',
				body: editBody,
			}),
			invalidatesTags: [{ type: 'Articles', id: 'LIST' }],
		}),
		getArticlesCreatedBy: build.query({
			query: (name) => `/post/users/${name}`,
		}),
	}),
})

export const {
	useGetArticlesListQuery,
	useGetSingleArticleQuery,
	useCreateArticleMutation,
	useEditArticleMutation,
	useGetArticlesCreatedByQuery,
} = articleApi
