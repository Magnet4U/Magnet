package services;

import java.io.Serializable;
import java.util.ArrayList;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.TypedQuery;

import entites.Reclamation;


@Stateless
@LocalBean
public class ReclamationService implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@PersistenceContext(unitName = "primary")
	EntityManager em;
	public void ajouterReclamation(Reclamation p) {em.persist(p);}
	public void supprimer(int id )
	{
		Reclamation entity = new Reclamation();
		Query query =
				em.createQuery("SELECT e FROM Reclamation e WHERE e.recId=:id  ",
						Reclamation.class);
				query.setParameter("id", id);
			entity=(Reclamation) query.getSingleResult();
		em.remove(entity);
	}
	public ArrayList<Reclamation> getRec(int id )
	{	ArrayList<Reclamation> p ;
	TypedQuery<Reclamation> query = em
			.createQuery("select c from Reclamation c WHERE c.user.userId=:id", Reclamation.class);
	query.setParameter("id", id);
		p = (ArrayList<Reclamation>) query.getResultList();
		return p;}

}
