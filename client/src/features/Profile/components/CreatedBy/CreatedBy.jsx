import React from 'react'
import { Container, Grid } from '@mui/material'
import { ArticlePreview } from '../../../../components/ArticlePreview/ArticlePreview'
import { useGetArticlesCreatedByQuery } from '../../../../services/articleApi'
import MoreHorizIcon from '@mui/icons-material/MoreHoriz'
import { getDecodedName } from '../../helpers/getDecodedName'

export const CreatedBy = () => {
	const { data, isLoading } = useGetArticlesCreatedByQuery(getDecodedName())
	return (
		<Container>
			<Grid container spacing={2} sx={{ mt: '25px', ml: '-10px' }}>
				<Grid item xs={8}>
					<Grid container spacing={2} sx={{ mt: 0, ml: '-10px' }}>
						{isLoading ? (
							<h3>Loading ...</h3>
						) : (
							data.map((item) => {
								return (
									<ArticlePreview
										key={item.id}
										isLabel={true}
										Icon={<MoreHorizIcon />}
										{...item}
									/>
								)
							})
						)}
					</Grid>
				</Grid>
				<Grid item xs={4}>
					WIP
				</Grid>
			</Grid>
		</Container>
	)
}
