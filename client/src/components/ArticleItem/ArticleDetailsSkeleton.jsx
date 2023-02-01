import React from 'react'
import { Skeleton } from '@mui/material'

export const ArticleDetailsSkeleton = () => {
	return (
		<>
			<Skeleton variant='text' sx={{ fontSize: '12px' }} animation='wave' />
			<Skeleton variant='text' sx={{ fontSize: '30px' }} animation='wave' />
			<Skeleton variant='text' sx={{ fontSize: '20px' }} animation='wave' />
			<Skeleton variant='rounded' height={270} sx={{ mb: '16px' }} animation='wave' />
			<Skeleton variant='rounded' height={270} animation='wave' />
		</>
	)
}
