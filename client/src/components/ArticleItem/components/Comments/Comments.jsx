import React from 'react'
import styles from './Coments.module.scss'
import { Box } from '@mui/material'
import { SingleComment } from './SingleComment'

export const Comments = ({ comments = [] }) => {
	return (
		<div className={styles.section}>
			<Box sx={{ display: 'flex' }}>
				<div className={styles.title}>Comments </div>
				<span className={styles.stats_number}>2.5K</span>
			</Box>
			<div className={styles.comments_container}>
				{comments &&
					comments.map((item) => {
						return <SingleComment key={item.id} {...item} />
					})}
			</div>
		</div>
	)
}
