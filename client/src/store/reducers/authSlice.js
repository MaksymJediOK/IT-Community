import { createSlice } from '@reduxjs/toolkit'

const authSlice = createSlice({
	name: 'auth',
	initialState: {
		user: {},
	},
	reducers: {
		setCredentials: (state, action) => {
			const { user, accessToken } = action.payload
			state.user = user
			localStorage.setItem('token', accessToken)
			return state
		},
		logOut: (state) => {
			state.user = null
			return state
		},
	},
})

export const { setCredentials, logOut } = authSlice.actions

export const authReducer = authSlice.reducer

export const selectCurrentUser = (state) => state.auth.user
