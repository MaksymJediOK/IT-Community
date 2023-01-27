import React from 'react'
import styles from './ArticleDetails.module.scss'
import { useParams } from 'react-router-dom'
import { Container, Grid } from '@mui/material'
import { ItemCard } from './components/ItemCard/ItemCard'
import { AuthorInfo } from './components/AuthorInfo/AuthorInfo'
import { Comments } from './components/Comments/Comments'

export const ArticleDetails = () => {
	const { id } = useParams()
	return (
		<Container>
			<div className={styles.crumbs}>IT ROOM / Articles</div>
			<Grid container spacing={3}>
				<Grid item xs={8}>
					<ItemCard />
					<Comments />
				</Grid>
				<Grid item xs={4}>
					<AuthorInfo />
				</Grid>
			</Grid>
		</Container>
	)
}
