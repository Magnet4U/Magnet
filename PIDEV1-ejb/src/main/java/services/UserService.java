package services;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;


import entites.User;
import iServicesRemote.UserServiceRemote;

@Stateless
@LocalBean
public class UserService implements UserServiceRemote{
	@PersistenceContext(unitName = "primary")
	EntityManager em;
	public User getEmployeByEmailAndPassword(String login, String password) {
		TypedQuery<User> query = em
				.createQuery("select e from User e where e.login=:login AND e.password=:password", User.class);
		query.setParameter("login", login);
		query.setParameter("password", password);
		User employe = null;
		try {
			employe = query.getSingleResult();
		} catch (Exception

		e) {
			System.out.println("Erreur : " + e);
		}

		return employe;
	}
}
