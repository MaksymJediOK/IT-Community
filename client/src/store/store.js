import { configureStore } from '@reduxjs/toolkit'
import { articleApi } from '../services/articleApi'
import { searchReducer } from './reducers/searchSlice'
import { authApi } from '../services/authApi'
import { authReducer } from './reducers/authSlice'
import { tagsApi } from '../services/tagsApi'
import { filterReducer } from './reducers/filterSlice'
import { articleActionReducer } from './reducers/articleActionSlice'
import { popoverReducer } from '../features/Popover'

export const store = configureStore({
	reducer: {
		search: searchReducer,
		[articleApi.reducerPath]: articleApi.reducer,
		[authApi.reducerPath]: authApi.reducer,
		auth: authReducer,
		[tagsApi.reducerPath]: tagsApi.reducer,
		filter: filterReducer,
		articleErrors: articleActionReducer,
		userPopover: popoverReducer,
	},
	middleware: (getDefaultMiddleware) =>
		getDefaultMiddleware({
			serializableCheck: false,
		}).concat(articleApi.middleware, authApi.middleware, tagsApi.middleware),
})
