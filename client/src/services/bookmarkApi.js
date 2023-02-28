import { fetchBaseQuery, createApi } from '@reduxjs/toolkit/query/react'

//ToDo move baseQuery to lower level
const baseQuery = fetchBaseQuery({
	baseUrl: 'http://itcommunity.somee.com/api',
	prepareHeaders: (headers) => {
		const token = localStorage.getItem('token')
		if (token) {
			headers.set('Authorization', `Bearer ${token}`)
		}
		return headers
	},
})
export const bookmarkApi = createApi({
	reducerPath: 'Bookmarks',
	tagTypes: ['bookmarks'],
	baseQuery,
	endpoints: (builder) => ({
		addToBookmarks: builder.mutation({
			query: (postId) => ({
				url: `/bookmark/${postId}`,
				method: 'POST',
			}),
		}),
		isBookmarked: builder.query({
			query: (id = 1) => `/bookmark/user/${id}`,
		}),
		getBookmarkedArticles: builder.query({
			query: () => '/bookmark/user',
		}),
	}),
})

export const { useAddToBookmarksMutation, useIsBookmarkedQuery, useGetBookmarkedArticlesQuery } =
	bookmarkApi
