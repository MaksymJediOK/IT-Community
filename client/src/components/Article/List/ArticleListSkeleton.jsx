import React from 'react'
import { Grid, Skeleton } from '@mui/material'

export const ArticleListSkeleton = () => {
	return (
		<>
			<Grid item xs={6}>
				<Skeleton variant='rounded' width={368} height={162} animation='wave' />
				<Skeleton variant='text' width={368} animation='wave' />
				<Skeleton variant='text' width={368} sx={{ fontSize: '20px' }} animation='wave' />
				<Skeleton variant='rounded' width={'60%'} height={20} animation='wave' />
				<Skeleton
					variant='rounded'
					width={'35%'}
					height={12}
					sx={{ mt: '8px' }}
					animation='wave'
				/>
			</Grid>
			<Grid item xs={6}>
				<Skeleton variant='rounded' width={368} height={162} animation='wave' />
				<Skeleton variant='text' width={368} animation='wave' />
				<Skeleton variant='text' width={368} sx={{ fontSize: '20px' }} animation='wave' />
				<Skeleton variant='rounded' width={'60%'} height={20} animation='wave' />
				<Skeleton
					variant='rounded'
					width={'35%'}
					height={12}
					sx={{ mt: '8px' }}
					animation='wave'
				/>
			</Grid>
			<Grid item xs={6}>
				<Skeleton variant='rounded' width={368} height={162} animation='wave' />
				<Skeleton variant='text' width={368} animation='wave' />
				<Skeleton variant='text' width={368} sx={{ fontSize: '20px' }} animation='wave' />
				<Skeleton variant='rounded' width={'60%'} height={20} animation='wave' />
				<Skeleton
					variant='rounded'
					width={'35%'}
					height={12}
					sx={{ mt: '8px' }}
					animation='wave'
				/>
			</Grid>
			<Grid item xs={6}>
				<Skeleton variant='rounded' width={368} height={162} animation='wave' />
				<Skeleton variant='text' width={368} animation='wave' />
				<Skeleton variant='text' width={368} sx={{ fontSize: '20px' }} animation='wave' />
				<Skeleton variant='rounded' width={'60%'} height={20} animation='wave' />
				<Skeleton
					variant='rounded'
					width={'35%'}
					height={12}
					sx={{ mt: '8px' }}
					animation='wave'
				/>
			</Grid>
		</>
	)
}
