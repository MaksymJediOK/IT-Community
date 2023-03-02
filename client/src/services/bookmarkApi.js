import { createApi } from '@reduxjs/toolkit/query/react'
import { baseQuery } from './baseQuery'

export const bookmarkApi = createApi({
	reducerPath: 'Bookmarks',
	tagTypes: ['bookmarks'],
	baseQuery: baseQuery,
	endpoints: (builder) => ({
		getBookmarkedArticles: builder.query({
			query: () => '/bookmark/user',
			providesTags: (result) =>
				result
					? [
							...result.map(({ id }) => ({ type: 'Bookmarks', id })),
							{ type: 'Bookmarks', id: 'FAV' },
					  ]
					: [{ type: 'Bookmarks', id: 'FAV' }],
		}),
		addToBookmarks: builder.mutation({
			query: (postId) => ({
				url: `/bookmark/${postId}`,
				method: 'POST',
			}),
			invalidatesTags: [{ type: 'Bookmarks', id: 'FAV' }],
		}),
		isBookmarked: builder.query({
			query: (id = 1) => `/bookmark/user/${id}`,
		}),
	}),
})

export const { useAddToBookmarksMutation, useIsBookmarkedQuery, useGetBookmarkedArticlesQuery } =
	bookmarkApi
